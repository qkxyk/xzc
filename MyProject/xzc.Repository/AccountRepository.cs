using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xzc.Model;
using xzc.Infrastructure;

namespace xzc.Repository
{
    public class AccountRepository : IAccountRepository, IUintOfWorkRepository
    {
        private IUnitOfWork _unitofWork;
        public AccountRepository(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public void Add(Account account)
        {
            _unitofWork.RegisterNew(account, this);
        }
        public void Remove(Account account)
        {
            _unitofWork.RegisterRemoved(account, this);
        }

        public void Save(Account account)
        {
            _unitofWork.RegisterAmended(account, this);
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            throw new NotImplementedException();
        }


    }
}
