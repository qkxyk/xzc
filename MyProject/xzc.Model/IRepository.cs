using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xzc.Model
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAll(int index, int count);

        IEnumerable<T> FindBy(Query query);
        IEnumerable<T> FindBy(Query query, int index, int count);

        T FindBy(Guid Id);

        void Save(T entity);
        void Add(T entity);
        void Remove(T entity);
    }
}
