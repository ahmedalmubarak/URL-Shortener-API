using TinyLink.API.Infrastrucure.Repository;
using TinyLink.API.Models;
using TinyLink.API.Models.Entities;
using TinyLink.API.Utilities;

namespace TinyLink.API.Services
{
    public class TinyLinkService
        (
        IVisitRepository _visitRepository,
        ITinyLinkRepository _tinyLinkRepository
        ) : ITinyLinkService
    {
        private string baseUrl = "https://localhost:7119/";
        public async Task<Link> CreateTinyLink(CreateTinyLinkCommand command)
        {
            var hash = HashHelper.GenrateHash(command.OriginalUrl);
            var link = new Link()
            {
                OriginalUrl = command.OriginalUrl,
                Hash = hash,
                ShortenedUrl = $"{baseUrl}{hash}"
            };
            var tinyLink = await _tinyLinkRepository.GetTinyLinkByHash(hash);
            if (tinyLink is not null)
            {
                return tinyLink;
            }
            var response = await _tinyLinkRepository.AddLink(link);
            return response;
        }
        public async Task RecordVisits(TinyLinkQuery query)
        {
            var hash = query.TinyLink.Split("/").Last();
            var tinyLink = await _tinyLinkRepository.GetTinyLinkByHash(hash) ??
                throw new ArgumentException("Tiny Link not found!");
            var visit = await _visitRepository.GetVisitByQuery(new VisitQuery
            {
                LinkId = tinyLink.Id,
                Device = query.Device,
                IPAddress = query.IPAddress,

            });
            if (visit is null)
            {
                await _visitRepository.AddVisit(new Visit
                {
                    LinkId = tinyLink.Id,
                    Device = query.Device,
                    IPAddress = query.IPAddress,
                    Count = 1,
                });
                return;
            }
            visit.Count++;
            visit.ModeifiedDateTime = DateTime.UtcNow;
            await _visitRepository.UpdateVisit(visit);
        }
        public async Task<string> GetOriginalLink(TinyLinkQuery query)
        {
            var hash = query.TinyLink.Split("/").Last();
            var tinyLink = await _tinyLinkRepository.GetTinyLinkByHash(hash) ??
                throw new ArgumentException("Tiny Link not found!");

            return tinyLink.OriginalUrl;
        }
    }
}
