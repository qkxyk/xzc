using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace xzc.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<IAggregateRoot, IUintOfWorkRepository> addedEntities;
        private Dictionary<IAggregateRoot, IUintOfWorkRepository> changedEntities;
        private Dictionary<IAggregateRoot, IUintOfWorkRepository> deletedEntities;

        public UnitOfWork()
        {
            addedEntities = new Dictionary<IAggregateRoot, IUintOfWorkRepository>();
            changedEntities = new Dictionary<IAggregateRoot, IUintOfWorkRepository>();
            deletedEntities = new Dictionary<IAggregateRoot, IUintOfWorkRepository>();
        }

        public void RegisterAmended(IAggregateRoot entity, IUintOfWorkRepository unitofWorkRepository)
        {
            if (!changedEntities.ContainsKey(entity))
            {
                changedEntities.Add(entity, unitofWorkRepository);
            }
        }

        public void RegisterNew(IAggregateRoot entity, IUintOfWorkRepository unitofWorkRepository)
        {
            if (!addedEntities.ContainsKey(entity))
            {
                addedEntities.Add(entity, unitofWorkRepository);
            }
        }

        public void RegisterRemoved(IAggregateRoot entity, IUintOfWorkRepository unitofWorkRepository)
        {
            if (!deletedEntities.ContainsKey(entity))
            {
                deletedEntities.Add(entity,unitofWorkRepository);
            }
        }
        public void Commit()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (IAggregateRoot item in addedEntities.Keys)
                {
                    addedEntities[item].PersistCreationOf(item);
                }
                foreach (IAggregateRoot item in changedEntities.Keys)
                {
                    changedEntities[item].PersistUpdateOf(item);
                }
                foreach (IAggregateRoot item in deletedEntities.Keys)
                {
                    deletedEntities[item].PersistDeletionOf(item);
                }
                scope.Complete();
            }
        }
    }
}
