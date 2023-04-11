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
   
    public class Document_typesRepository : IDocuments_typeRepository
    {
        private readonly dbaeusdsdevpamecContext _db;
        private DbSet<Documents_type> Entity => _db.Set<Documents_type>();

        public Document_typesRepository(dbaeusdsdevpamecContext db)
        {
            this._db = db;
        }

        public async Task<int> AddAsync(List<Documents_type> values)
        {
            await Entity.AddRangeAsync(values);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> AddAsync(Documents_type value)
        {
            await Entity.AddAsync(value);

            return await _db.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(Documents_type value = null, Expression<Func<Documents_type, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(List<Documents_type> values = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Documents_type>> GetAllAsync(Expression<Func<Documents_type, bool>> predicate = null, Func<IQueryable<Documents_type>, IIncludableQueryable<Documents_type, object>> include = null, Func<IQueryable<Documents_type>, IOrderedQueryable<Documents_type>> orderBy = null, Expression<Func<Documents_type, Documents_type>> selector = null)
        {
            IQueryable<Documents_type> query = Entity.AsNoTracking();

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

        public async Task<Documents_type> GetAsync(Expression<Func<Documents_type, bool>> predicate = null, Func<IQueryable<Documents_type>, IIncludableQueryable<Documents_type, object>> include = null, Func<IQueryable<Documents_type>, IOrderedQueryable<Documents_type>> orderBy = null, Expression<Func<Documents_type, Documents_type>> selector = null)
        {
            IQueryable<Documents_type> query = Entity.AsNoTracking();

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

        public async Task<int> UpdateAsync(List<Documents_type> values, params Expression<Func<Documents_type, object>>[] propertyExpressions)
        {
            foreach (var value in values)
            {
                await UpdateAsync(value, propertyExpressions);
            }
            return await Task.Run(() => values.Count);
        }

        public async Task<int> UpdateAsync(Documents_type value, params Expression<Func<Documents_type, object>>[] propertyExpressions)
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
