using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demography.plugins.contracts.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get<TId>(TId id);
        bool Add(T item);
        bool Delete<TId>(TId id);
    }
}
