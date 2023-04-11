namespace Backend.Shared.Entities.Interface.Repository.Base
{
    /// <summary>
    /// IBaseRepositoryCommonsMySQL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="IBaseRepository&lt;T&gt;" />
    public interface IBaseRepositoryCommonsMySQL<T> : IBaseRepository<T> where T : class
    {
    }
}