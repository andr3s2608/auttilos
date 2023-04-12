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
    public  class Procedure_requestsRepository:  IProcedure_requestsRepository
    {
        private readonly dbaeusdsdevpamecContext _db;
        private DbSet<procedure_requests> Entity => _db.Set<procedure_requests>();

        public Procedure_requestsRepository(dbaeusdsdevpamecContext db)
        {
            this._db = db;
        }

        public async Task<int> AddAsync(List<procedure_requests> values)
        {
            await Entity.AddRangeAsync(values);

            return await _db.SaveChangesAsync();

        }

        public async Task<int> AddAsync(procedure_requests value)
        {
            await Entity.AddAsync(value);

            return await _db.SaveChangesAsync();

        }

        public Task<int> DeleteAsync(procedure_requests value = null, Expression<Func<procedure_requests, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(List<procedure_requests> values = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<procedure_requests>> GetAllAsync(Expression<Func<procedure_requests,
            bool>> predicate = null, Func<IQueryable<procedure_requests>,
                IIncludableQueryable<procedure_requests, object>> include = null,
            Func<IQueryable<procedure_requests>, IOrderedQueryable<procedure_requests>> orderBy = null,
            Expression<Func<procedure_requests, procedure_requests>> selector = null)
        {
            IQueryable<procedure_requests> query = Entity.AsNoTracking();

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

        public async Task<procedure_requests> GetAsync(Expression<Func<procedure_requests,
            bool>> predicate = null, Func<IQueryable<procedure_requests>,
                IIncludableQueryable<procedure_requests, object>> include = null,
            Func<IQueryable<procedure_requests>, IOrderedQueryable<procedure_requests>> orderBy = null, 
            Expression<Func<procedure_requests, procedure_requests>> selector = null)
        {
            IQueryable<procedure_requests> query = Entity.AsNoTracking();

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

        public async Task<int> UpdateAsync(List<procedure_requests> values, params Expression<Func<procedure_requests, object>>[] propertyExpressions)
        {
            foreach (var value in values)
            {
                await UpdateAsync(value, propertyExpressions);
            }
            return await Task.Run(() => values.Count);
        }

        public async Task<int> UpdateAsync(procedure_requests value, params Expression<Func<procedure_requests, object>>[] propertyExpressions)
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
