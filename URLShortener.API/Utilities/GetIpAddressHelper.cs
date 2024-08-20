namespace TinyLink.API.Utilities
{
    public class GetIpAddressHelper
    {
        public static string GetClientIpAddress(HttpContext httpContext)
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
