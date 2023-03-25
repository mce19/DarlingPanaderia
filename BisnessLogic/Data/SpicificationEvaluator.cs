using CoreEntities.Entities;
using CoreEntities.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnessLogic.Data
{
    public class SpicificationEvaluator<T> where T : ClaseBase
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpicification<T> spec)
        {
            if (spec.Criteria != null)
            {
                inputQuery = inputQuery.Where(spec.Criteria);
            }

            inputQuery = spec.Includes.Aggregate(inputQuery, (current, include) => current.Include(include));
            return inputQuery;
        }
    }
}