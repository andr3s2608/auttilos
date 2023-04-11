using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Repositories.Base
{
    public class BaseRepositoryAuttitulos<T> : BaseRepository<T>, Entities.Interface.Repository.Base.IBaseRepositoryAuttitulos<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepositoryAguaConsumoHumano{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BaseRepositoryAuttitulos(Backend.Shared.Repositories.Context.dbaeusdsdevpamecContext context)
        {
            AppContext = context;
        }
    }
}
