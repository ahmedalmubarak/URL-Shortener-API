using TinyLink.API.Models;
using TinyLink.API.Models.Entities;

namespace TinyLink.API.Infrastrucure.Repository
{
    public interface IVisitRepository : IBaseRepository<Visit>
    {
        Task<Visit> GetVisitByQuery(VisitQuery query);
    }
}
