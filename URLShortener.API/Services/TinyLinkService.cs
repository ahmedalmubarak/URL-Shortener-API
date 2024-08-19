using TinyLink.API.Infrastrucure;
using TinyLink.API.Models;
using TinyLink.API.Models.Entities;
using TinyLink.API.Utilities;

namespace TinyLink.API.Services
{
    public class TinyLinkService : ITinyLinkService


    {
        private readonly IUnitOfWork _unitOfWork;

        public TinyLinkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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
            var tinyLink = await _unitOfWork.LinkRepository.GetTinyLinkByHash(hash);
            if (tinyLink is not null)
            {
                return tinyLink;
            }
            var response = await _unitOfWork.LinkRepository.Add(link);
            await _unitOfWork.Complete();
            return response;
        }
        public async Task RecordVisits(TinyLinkQuery query)
        {
            var hash = query.TinyLink.Split("/").Last();
            var tinyLink = await _unitOfWork.LinkRepository.GetTinyLinkByHash(hash) ??
                throw new ArgumentException("Tiny Link not found!");
            var visit = await _unitOfWork.VisitRepository.GetVisitByQuery(new VisitQuery
            {
                LinkId = tinyLink.Id,
                Device = query.Device,
                IPAddress = query.IPAddress,

            });
            if (visit is null)
            {
                await _unitOfWork.VisitRepository.Add(new Visit
                {
                    LinkId = tinyLink.Id,
                    Device = query.Device,
                    IPAddress = query.IPAddress,
                    Count = 1,
                });
                await _unitOfWork.Complete();
                return;
            }
            visit.Count++;
            visit.ModeifiedDateTime = DateTime.UtcNow;
            await _unitOfWork.VisitRepository.Update(visit);
            await _unitOfWork.Complete();
        }
        public async Task<string> GetOriginalLink(TinyLinkQuery query)
        {
            var hash = query.TinyLink.Split("/").Last();
            var tinyLink = await _unitOfWork.LinkRepository.GetTinyLinkByHash(hash) ??
                throw new ArgumentException("Tiny Link not found!");

            return tinyLink.OriginalUrl;
        }
    }
}
