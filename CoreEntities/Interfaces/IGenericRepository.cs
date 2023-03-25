using CoreEntities.Entities;
using CoreEntities.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities.Interfaces
{
    public interface IGenericRepository<T> where T : ClaseBase
    {
        //operaciones genericas para consultar cualquier tabla
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdWithSpec(ISpicification<T> spec);

        Task<IReadOnlyList<T>> GetAllWithSpec(ISpicification<T> spec);
    }
}