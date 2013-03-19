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
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(entity);
                transaction.Commit();
            }
        }

        public void Update(T entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Merge(entity);
                transaction.Commit();
            }
        }

        public void Flush()
        {
            _session.Flush();
        }

        public T Get(int id)
        {
            return _session.Get<T>(id);
        }

        public void Remove(T entity)
        {
            _session.Delete(entity);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _session.Query<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression
        {
            get
            {
                return _session.Query<T>().Expression;
            }
        }
        
        public Type ElementType
        {
            get
            {
                return _session.Query<T>().ElementType;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return _session.Query<T>().Provider;
            }
        }
    }
}