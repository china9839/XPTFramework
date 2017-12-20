using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.DataAccess
{
    public static class DBContextExtend
    {
        public static List<dynamic> LoadByPage<T, TKey>(this DbContext dbContext,
            Expression<Func<T, dynamic>> select,
            int pageIndex,
            int pageSize,
            Expression<Func<T, TKey>> order,
            out int Total,
            Expression<Func<T, bool>> where = null,
            bool isAsc = true) 
            where T:class
        {
            if (where == null)
            {
                where = t => true;
            }
            Total = dbContext.Set<T>().AsNoTracking().Where(where).Count();
            if (isAsc)
            {
                var list = dbContext.Set<T>().AsNoTracking().Where(where).OrderBy(order).Select(select).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                return list.ToList();
            }
            else {
                var list = dbContext.Set<T>().AsNoTracking().Where(where).OrderByDescending(order).Select(select).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                return list.ToList();
            }
            
        }

        public static List<T> LoadByPage<T, TKey>(
            this IPathDBEntities dbContext,
            int pageIndex,
            int pageSize,
            Expression<Func<T, TKey>> order,
            out int Total,
            Expression<Func<T, bool>> where = null,
            bool isAsc = true) where T : class
        {
            if (where == null)
            {
                where = t => true;
            }
            Total = dbContext.Set<T>().AsNoTracking().Where(where).Count();
            if (isAsc)
            {
                var list = dbContext.Set<T>().AsNoTracking().Where(where).OrderBy(order).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                return list.ToList();
            }
            else {
                var list = dbContext.Set<T>().AsNoTracking().Where(where).OrderByDescending(order).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                return list.ToList();
            }
            
        }
    }
}
