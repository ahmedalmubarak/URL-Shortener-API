using Microsoft.AspNetCore.Mvc;
using TinyLink.API.Models;
using TinyLink.API.Services;

namespace TinyLink.API.Controllers
{
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
            var iPAddress = GetClientIpAddress(HttpContext);
            var device = HttpContext.Request.Headers["User-Agent"];

            var orignalLink = await _tinyLinkService.GetOriginalLink(new TinyLinkQuery
            {
                Device = device,
                IPAddress = iPAddress,
                TinyLink = tinyLinkRequest.TinyLink,

            });
            return Redirect(orignalLink);
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
