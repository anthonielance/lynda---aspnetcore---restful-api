using Newtonsoft.Json;

namespace LandonAPI.Models
{
    public abstract class Resource : Link
    {
        [JsonIgnore]
        public Link Self { get; set; }
    }
}
