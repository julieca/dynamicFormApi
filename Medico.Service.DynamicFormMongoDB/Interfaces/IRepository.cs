using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medico.Service.DynamicFormMongoDB.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(string id);
        Task<T> Add(T item);
        Task<Tuple<T, T>> Update(string id, T item);
        Task<T> Delete(string id);
    }
}
