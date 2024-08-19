using TinyLink.API.Infrastrucure.Repository;

namespace TinyLink.API.Infrastrucure
{
    public interface IUnitOfWork : IDisposable
    {
        ITinyLinkRepository LinkRepository { get; }
        IVisitRepository VisitRepository { get; }
        Task<int> Complete();
    }
}
