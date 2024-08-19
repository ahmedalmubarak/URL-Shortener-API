using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TinyLink.API.Models;
using TinyLink.API.Services;

namespace TinyLink.API.Controllers.V1
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    public class TinyLinkController(ITinyLinkService _tinyLinkService) : ControllerBase
    {
        [HttpPost]
        [Route("CreateTinyLink")]
        public async Task<IActionResult> CreateTinyLink(CreateTinyLinkRequest createTinyLink)
        {
            var command = new CreateTinyLinkCommand
            {
                OriginalUrl = createTinyLink.OriginalUrl,
            };
            var tinyLink = await _tinyLinkService.CreateTinyLink(command);
            return Ok(tinyLink);
        }

        [HttpGet]
        [Route("QueryTinyLink")]
        public async Task<IActionResult> QueryTinyLink(TinyLinkRequest tinyLinkRequest)
        {
            var ipAddress = GetClientIpAddress(HttpContext);
            var userAgent = HttpContext.Request.Headers["User-Agent"];

            var query = new TinyLinkQuery
            {
                Device = userAgent,
                IPAddress = ipAddress,
                TinyLink = tinyLinkRequest.TinyLink,

            };
            await _tinyLinkService.RecordVisits(query);
            var originalTinyLink = await _tinyLinkService.GetOriginalLink(query);
            return Redirect(originalTinyLink);
        }
        private string GetClientIpAddress(HttpContext httpContext)
        {
            var clientIp = httpContext.Request.Headers["X-Real-IP"].ToString();

            if (string.IsNullOrEmpty(clientIp))
            {
                clientIp = httpContext.Connection.RemoteIpAddress.ToString();
            }
            return clientIp;
        }
    }
}
