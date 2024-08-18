using TinyLink.API.Models;
using TinyLink.API.Models.Entities;

namespace TinyLink.API.Infrastrucure.Repository
{
    public interface IVisitRepository
    {

        Task<Visit> AddVisit(Visit visit);
        Task<Visit> GetVisitByQuery(VisitQuery query);
        Task<bool> SaveChangesAsync();
        Task<Visit> UpdateVisit(Visit visit);

    }
}
