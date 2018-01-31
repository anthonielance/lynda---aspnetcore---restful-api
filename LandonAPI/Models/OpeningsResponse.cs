namespace LandonAPI.Models
{
    public class OpeningsResponse : PagedCollection<Opening>
    {
        public Form OpeningsQuery { get; set; }
    }
}
