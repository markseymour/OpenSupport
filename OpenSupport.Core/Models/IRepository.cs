using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace OpenSupport.Core.Models
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        void Flush();

        T Get(int id);
        IEnumerable<T> Fetch(Func<T, bool> predicate);
        IEnumerable<T> FetchAll();
    }
}
