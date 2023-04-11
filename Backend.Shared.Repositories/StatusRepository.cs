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
    public class StatusRepository : IStatusRepository
    {
        private readonly dbaeusdsdevpamecContext _db;
        private DbSet<Status_types> Entity => _db.Set<Status_types>();

        public StatusRepository(dbaeusdsdevpamecContext db)
        {
            this._db = db;
        }

        public async Task<int> AddAsync(List<Status_types> values)
        {
            await Entity.AddRangeAsync(values);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> AddAsync(Status_types value)
        {
            await Entity.AddAsync(value);

            return await _db.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(Status_types value = null, Expression<Func<Status_types, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(List<Status_types> values = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Status_types>> GetAllAsync(Expression<Func<Status_types, bool>> predicate = null, Func<IQueryable<Status_types>, IIncludableQueryable<Status_types, object>> include = null, Func<IQueryable<Status_types>, IOrderedQueryable<Status_types>> orderBy = null, Expression<Func<Status_types, Status_types>> selector = null)
        {
            IQueryable<Status_types> query = Entity.AsNoTracking();

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

        public async Task<Status_types> GetAsync(Expression<Func<Status_types, bool>> predicate = null, Func<IQueryable<Status_types>, IIncludableQueryable<Status_types, object>> include = null, Func<IQueryable<Status_types>, IOrderedQueryable<Status_types>> orderBy = null, Expression<Func<Status_types, Status_types>> selector = null)
        {
            IQueryable<Status_types> query = Entity.AsNoTracking();

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

        public async Task<int> UpdateAsync(List<Status_types> values, params Expression<Func<Status_types, object>>[] propertyExpressions)
        {
            foreach (var value in values)
            {
                await UpdateAsync(value, propertyExpressions);
            }
            return await Task.Run(() => values.Count);
        }

        public async Task<int> UpdateAsync(Status_types value, params Expression<Func<Status_types, object>>[] propertyExpressions)
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
