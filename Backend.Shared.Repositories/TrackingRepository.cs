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
    public class TrackingRepository : ITrackingRepository
    {
        private readonly dbaeusdsdevpamecContext _db;
        private DbSet<Tracking> Entity => _db.Set<Tracking>();

        public TrackingRepository (dbaeusdsdevpamecContext db)
        {
            this._db = db;
        }

        public async Task<int> AddAsync(List<Tracking> values)
        {
            await Entity.AddRangeAsync(values);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> AddAsync(Tracking value)
        {
            await Entity.AddAsync(value);

            return await _db.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(Tracking value = null, Expression<Func<Tracking, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(List<Tracking> values = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Tracking>> GetAllAsync(Expression<Func<Tracking, bool>> predicate = null, Func<IQueryable<Tracking>, IIncludableQueryable<Tracking, object>> include = null, Func<IQueryable<Tracking>, IOrderedQueryable<Tracking>> orderBy = null, Expression<Func<Tracking, Tracking>> selector = null)
        {
            IQueryable<Tracking> query = Entity.AsNoTracking();

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

        public async Task<Tracking> GetAsync(Expression<Func<Tracking, bool>> predicate = null, Func<IQueryable<Tracking>, IIncludableQueryable<Tracking, object>> include = null, Func<IQueryable<Tracking>, IOrderedQueryable<Tracking>> orderBy = null, Expression<Func<Tracking, Tracking>> selector = null)
        {
            IQueryable<Tracking> query = Entity.AsNoTracking();

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

        public async Task<int> UpdateAsync(List<Tracking> values, params Expression<Func<Tracking, object>>[] propertyExpressions)
        {
            foreach (var value in values)
            {
                await UpdateAsync(value, propertyExpressions);
            }
            return await Task.Run(() => values.Count);
        }

        public async Task<int> UpdateAsync(Tracking value, params Expression<Func<Tracking, object>>[] propertyExpressions)
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
