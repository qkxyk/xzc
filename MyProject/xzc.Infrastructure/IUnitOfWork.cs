using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xzc.Infrastructure
{
  public  interface IUnitOfWork
    {
        void RegisterAmended(IAggregateRoot entity, IUintOfWorkRepository unitofWorkRepository);
        void RegisterNew(IAggregateRoot entity, IUintOfWorkRepository unitofWorkRepository);
        void RegisterRemoved(IAggregateRoot entity, IUintOfWorkRepository unitofWorkRepository);
        void Commit();
    }
}
