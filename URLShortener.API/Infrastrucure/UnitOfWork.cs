using TinyLink.API.Infrastrucure.Repository;

namespace TinyLink.API.Infrastrucure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ITinyLinkRepository LinkRepository { get; private set; }

        public IVisitRepository VisitRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            LinkRepository = new TinyLinkRepository(_context);
            VisitRepository = new VisitRepository(_context);
        }


        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
