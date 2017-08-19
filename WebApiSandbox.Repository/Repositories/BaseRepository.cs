using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSandbox.Repository.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private ISession session = SessionFactoryProvider.GetCurrentSession();

        public IList<T> Get<T>() => session.Query<T>().ToList();

        public T Get<T>(int id) => session.Get<T>(id);

        public IList<T> GetWhere<T>(Func<T, bool> whereClause) => session.Query<T>()
            .Where(whereClause).ToList();

        public T Post<T>(T item)
        {
            session.SaveOrUpdate(item);
            return item;
        }
    }
}
