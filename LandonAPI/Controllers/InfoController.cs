using LandonAPI.Infrastructure;
using LandonAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LandonAPI.Controllers
{
    [Route("/[controller]")]
    public class InfoController : Controller
    {
        private HotelInfo _hotelInfo;

        public InfoController(IOptions<HotelInfo> hotelInfoAccessor) => _hotelInfo = hotelInfoAccessor.Value;

        [HttpGet(Name = nameof(GetInfo))]
        [ResponseCache(CacheProfileName = "Static")]
        [Etag]
        public IActionResult GetInfo()
        {
            _hotelInfo.Href = Url.Link(nameof(GetInfo), null);

            if (!Request.GetEtagHandler().NoneMatch(_hotelInfo)) return StatusCode(304, _hotelInfo);

            return Ok(_hotelInfo);
        }
    }
}
