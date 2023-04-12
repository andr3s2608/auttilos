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
    public  class Document_procedureRepository :  IDocument_procedureRepository
    {
        private readonly dbaeusdsdevpamecContext _db;
        private DbSet<Document_types_procedure> Entity => _db.Set<Document_types_procedure>();

        public Document_procedureRepository(dbaeusdsdevpamecContext db)
        {
            this._db = db;
        }

        public async Task<int> AddAsync(List<Document_types_procedure> values)
        {
            await Entity.AddRangeAsync(values);

            return await _db.SaveChangesAsync();

        }

        public async Task<int> AddAsync(Document_types_procedure value)
        {
            await Entity.AddAsync(value);

            return await _db.SaveChangesAsync();

        }

        public Task<int> DeleteAsync(Document_types_procedure value = null, Expression<Func<Document_types_procedure, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(List<Document_types_procedure> values = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Document_types_procedure>> GetAllAsync(Expression<Func<Document_types_procedure, 
            bool>> predicate = null, Func<IQueryable<Document_types_procedure>, 
                IIncludableQueryable<Document_types_procedure, object>> include = null,
            Func<IQueryable<Document_types_procedure>, IOrderedQueryable<Document_types_procedure>> orderBy = null,
            Expression<Func<Document_types_procedure, Document_types_procedure>> selector = null)
        {
            IQueryable<Document_types_procedure> query = Entity.AsNoTracking();

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

        public async Task<Document_types_procedure> GetAsync(Expression<Func<Document_types_procedure, bool>> predicate = null, Func<IQueryable<Document_types_procedure>, IIncludableQueryable<Document_types_procedure, object>> include = null, Func<IQueryable<Document_types_procedure>, IOrderedQueryable<Document_types_procedure>> orderBy = null, Expression<Func<Document_types_procedure, Document_types_procedure>> selector = null)
        {
            IQueryable<Document_types_procedure> query = Entity.AsNoTracking();

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

        public async Task<int> UpdateAsync(List<Document_types_procedure> values, params Expression<Func<Document_types_procedure, object>>[] propertyExpressions)
        {
            foreach (var value in values)
            {
                await UpdateAsync(value, propertyExpressions);
            }
            return await Task.Run(() => values.Count);
        }

        public async Task<int> UpdateAsync(Document_types_procedure value, params Expression<Func<Document_types_procedure, object>>[] propertyExpressions)
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
