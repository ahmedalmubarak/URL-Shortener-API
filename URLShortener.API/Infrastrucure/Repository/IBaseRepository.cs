namespace TinyLink.API.Infrastrucure.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);

    }
}
