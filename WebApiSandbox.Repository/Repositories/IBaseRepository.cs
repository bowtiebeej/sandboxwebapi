using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSandbox.Repository.Repositories
{
    public interface IBaseRepository
    {
        IList<T> Get<T>();
        T Get<T>(int id);
        IList<T> GetWhere<T>(Func<T, bool> whereClause);
        T Post<T>(T item);
    }
}
