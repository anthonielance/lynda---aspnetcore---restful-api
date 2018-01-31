using Microsoft.AspNetCore.Http;

namespace LandonAPI.Infrastructure
{
    public static class HttpRequestExtensions
    {
        public static IEtagHandlerFeature GetEtagHandler(this HttpRequest request)
            => request.HttpContext.Features.Get<IEtagHandlerFeature>();
    }
}
