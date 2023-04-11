namespace Backend.Shared.Entities.Interface.Repository.Base
{
    /// <summary>
    /// IBaseRepositoryCommonsSQLServer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="IBaseRepository&lt;T&gt;" />
    public interface IBaseRepositoryCommonsSQLServer<T> : IBaseRepository<T> where T : class
    {
    }
}