using Microsoft.AspNetCore.Mvc;
using TinyLink.API.Infrastrucure;
using TinyLink.API.Models;
using TinyLink.API.Models.Entities;
using TinyLink.API.Services;

namespace TinyLink.API.Controllers
{
    [ApiController]
    public class TinyLinkController(ApplicationDbContext _dbContext) : ControllerBase
    {
        [HttpPost]
        [Route("CreateTinyLink")]
        public IActionResult CreateTinyLink(CreateTinyLinkRequest createTinyLink)
        {
            var link = new TinyLinkService().CreateTinyLink(new CreateTinyLinkCommand
            {
                OriginalUrl = createTinyLink.OriginalUrl,
            });

            var response = _dbContext.Links.Add(link);
            _dbContext.SaveChanges();
            return Ok(response.Entity);
        }

        [HttpGet]
        [Route("QueryTinyLink")]
        public IActionResult QueryTinyLink(TinyLinkRequest q)
        {
            var hash = q.TinyLink.Split("/").Last();
            var tinyLink = _dbContext.Links.FirstOrDefault(x => x.Hash == hash);

            var ipAddress = GetClientIpAddress(HttpContext);
            string userAgent = HttpContext.Request.Headers["User-Agent"];

            if (_dbContext.Visits.Any(
                x => x.LinkId == tinyLink.Id &&
                x.IPAddress == ipAddress &&
                x.Device == userAgent
                )
            )
            {
                var visit = _dbContext.Visits.First(
                x => x.LinkId == tinyLink.Id &&
                x.IPAddress == ipAddress &&
                x.Device == userAgent);

                visit.Count++;
                visit.ModeifiedDateTime = DateTime.UtcNow;
                _dbContext.SaveChanges();
                return Redirect(tinyLink.OriginalUrl);
            }

            _dbContext.Visits.Add(new Visit
            {
                LinkId = tinyLink.Id,
                Device = userAgent,
                IPAddress = ipAddress,
                Count = 1,
            });
            _dbContext.SaveChanges();
            return Redirect(tinyLink.OriginalUrl);
        }
        private string GetClientIpAddress(HttpContext httpContext)
        {
            //Try to get client IP address from the X-Real-IP header
            var clientIp = httpContext.Request.Headers["X-Real-IP"].ToString();

            //If the X-Real-IP header is not present, fall back to the RemoteIpAddress property
            if (string.IsNullOrEmpty(clientIp))
            {
                clientIp = httpContext.Connection.RemoteIpAddress.ToString();
            }
            return clientIp;
        }
    }
}
