namespace TinyLink.API.Infrastrucure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            var response = await _context.Set<T>().AddAsync(entity);
            return response.Entity;
        }



        public async Task<T> Update(T entity)
        {
            var response = _context.Set<T>().Update(entity);
            return response.Entity;
        }
    }
}
