using Backend.Shared.Entities.Interface.Repository;
using Backend.Shared.Entities.Models.Auttitulos;
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
    public class EntitiesRepository : IEntitiesRepository
    {
        private readonly dbaeusdsdevpamecContext _db;
        private DbSet<Entities.Models.Auttitulos.Entities> Entity => _db.Set<Entities.Models.Auttitulos.Entities>();

        public EntitiesRepository(dbaeusdsdevpamecContext db)
        {
            this._db = db;
        }

        public async Task<int> AddAsync(List<Entities.Models.Auttitulos.Entities> values)
        {
            await Entity.AddRangeAsync(values);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> AddAsync(Entities.Models.Auttitulos.Entities value)
        {
            await Entity.AddAsync(value);

            return await _db.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(Entities.Models.Auttitulos.Entities value = null, Expression<Func<Entities.Models.Auttitulos.Entities, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(List<Entities.Models.Auttitulos.Entities> values = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Entities.Models.Auttitulos.Entities>> GetAllAsync(Expression<Func<Entities.Models.Auttitulos.Entities, bool>> predicate = null, Func<IQueryable<Entities.Models.Auttitulos.Entities>, IIncludableQueryable<Entities.Models.Auttitulos.Entities, object>> include = null, Func<IQueryable<Entities.Models.Auttitulos.Entities>, IOrderedQueryable<Entities.Models.Auttitulos.Entities>> orderBy = null, Expression<Func<Entities.Models.Auttitulos.Entities, Entities.Models.Auttitulos.Entities>> selector = null)
        {
            IQueryable<Entities.Models.Auttitulos.Entities> query = Entity.AsNoTracking();

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

        public async Task<Entities.Models.Auttitulos.Entities> GetAsync(Expression<Func<Entities.Models.Auttitulos.Entities, bool>> predicate = null, Func<IQueryable<Entities.Models.Auttitulos.Entities>, IIncludableQueryable<Entities.Models.Auttitulos.Entities, object>> include = null, Func<IQueryable<Entities.Models.Auttitulos.Entities>, IOrderedQueryable<Entities.Models.Auttitulos.Entities>> orderBy = null, Expression<Func<Entities.Models.Auttitulos.Entities, Entities.Models.Auttitulos.Entities>> selector = null)
        {
            IQueryable<Entities.Models.Auttitulos.Entities> query = Entity.AsNoTracking();

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

        public async Task<int> UpdateAsync(List<Entities.Models.Auttitulos.Entities> values, params Expression<Func<Entities.Models.Auttitulos.Entities, object>>[] propertyExpressions)
        {
            foreach (var value in values)
            {
                await UpdateAsync(value, propertyExpressions);
            }
            return await Task.Run(() => values.Count);
        }

        public async Task<int> UpdateAsync(Entities.Models.Auttitulos.Entities value, params Expression<Func<Entities.Models.Auttitulos.Entities, object>>[] propertyExpressions)
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
