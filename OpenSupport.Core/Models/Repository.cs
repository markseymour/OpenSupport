using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using NHibernate;
using NHibernate.Linq;

namespace OpenSupport.Core.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public void Add(T entity)
        {
            _session.Save(entity);
        }

        public void Update(T entity)
        {
            _session.Merge(entity);
        }

        public void Flush()
        {
            _session.Flush();
        }

        public T Get(int id)
        {
            return _session.Get<T>(id);
        }

        public IEnumerable<T> Fetch(Func<T, bool> predicate)
        {
            return _session.Query<T>().Where(predicate);
        }

        public IEnumerable<T> FetchAll()
        {
            return _session.Query<T>().AsEnumerable<T>();
        }

        public void Remove(T entity)
        {
            _session.Delete(entity);
        }
    }
}