using BisnessLogic.Data;
using CoreEntities.Entities;
using CoreEntities.Interfaces;
using CoreEntities.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnessLogic.Logic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ClaseBase
    {
        private readonly MarketDbContext _context;

        public GenericRepository(MarketDbContext context)
        {
            _context = context;
        }

        // para generar las interfacez le damos click derecho a IGenericRepository<T>   y crear interfaze
        public async Task<IReadOnlyList<T>> GetAllAsync() //para obtener todo los elemeentos  de la entidad generica y la letra T represeta cualquier tipo de clase de tipo entidad como categoria producto o marca
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id) // => await _context.Set<T>().FindAsync(id);    espresion landa cuando un metodo o funcion tiene una sola linea de codigo asi quedaria quitando los corchetes y el return y se agrega el =>
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdWithSpec(ISpicification<T> spec)
        {
            return await ApplySpecifcation(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpec(ISpicification<T> spec)
        {
            return await ApplySpecifcation(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecifcation(ISpicification<T> spec)
        {
            return SpicificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}