using Backend.Shared.Entities.Interface.Repository;
using Backend.Shared.Entities.Models.Pamec;
using Backend.Shared.Repositories.Context;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using System;


namespace Backend.Shared.Repositories
{
    public  class ConstantesRepository:  IConstantesRepository
    {
        private readonly dbaeusdsdevpamecContext _db;
        private DbSet<Constante> Entity => _db.Set<Constante>();

        public ConstantesRepository (dbaeusdsdevpamecContext db)
        {
            this._db = db;
        }

        public async Task<int> AddAsync(List<Constante> values)
        {
            await Entity.AddRangeAsync(values);

            return await _db.SaveChangesAsync();

        }

        public async Task<int> AddAsync(Constante value)
        {
            await Entity.AddAsync(value);

            return await _db.SaveChangesAsync();

        }

        public Task<int> DeleteAsync(Constante value = null, Expression<Func<Constante, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(List<Constante> values = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Constante>> GetAllAsync(Expression<Func<Constante, bool>> predicate = null, Func<IQueryable<Constante>, IIncludableQueryable<Constante, object>> include = null, Func<IQueryable<Constante>, IOrderedQueryable<Constante>> orderBy = null, Expression<Func<Constante, Constante>> selector = null)
        {
            IQueryable<Constante> query = Entity.AsNoTracking();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                if (selector != null)
                {
                    return await orderBy(query).Select(selector).ToListAsync();
                }

                return await orderBy(query).ToListAsync();
            }

            if (selector != null)
            {
                return await query.Select(selector).ToListAsync();
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Constante> GetAsync(Expression<Func<Constante, bool>> predicate = null, Func<IQueryable<Constante>, IIncludableQueryable<Constante, object>> include = null, Func<IQueryable<Constante>, IOrderedQueryable<Constante>> orderBy = null, Expression<Func<Constante, Constante>> selector = null)
        {
            IQueryable<Constante> query = Entity.AsNoTracking();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                if (selector != null)
                {
                    return await orderBy(query).Select(selector).FirstOrDefaultAsync();
                }

                return await orderBy(query).FirstOrDefaultAsync();
            }

            if (selector != null)
            {
                return await query.Select(selector).FirstOrDefaultAsync();
            }

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<int> UpdateAsync(List<Constante> values, params Expression<Func<Constante, object>>[] propertyExpressions)
        {
            foreach (var value in values)
            {
                await UpdateAsync(value, propertyExpressions);
            }
            return await Task.Run(() => values.Count);
        }

        public async Task<int> UpdateAsync(Constante value, params Expression<Func<Constante, object>>[] propertyExpressions)
        {
            if (propertyExpressions == null || propertyExpressions.Length <= 0)
            {
                var entity = Entity.Update(value);
                entity.State = EntityState.Modified;
            }
            else
            {
                Entity.Attach(value);
                foreach (var column in propertyExpressions)
                {
                    _db.Entry(value).Property(column).IsModified = true;
                }
            }

            return await _db.SaveChangesAsync();
        }
    }
}
