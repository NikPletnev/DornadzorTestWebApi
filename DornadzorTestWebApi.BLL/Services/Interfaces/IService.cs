using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DornadzorTestWebApi.BLL.Services.Interfaces
{
    public interface IService<T>
    {
        Task<int> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task Delete(int id);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
    }
}
