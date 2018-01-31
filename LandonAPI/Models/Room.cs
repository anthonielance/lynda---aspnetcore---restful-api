using LandonAPI.Infrastructure;

namespace LandonAPI.Models
{
    public class Room : Resource
    {
        [Sortable]
        [SearchableString]
        public string Name { get; set; }

        [Sortable(Default = true)]
        [SearchableDecimal]
        public decimal Rate { get; set; }

        public Form Book { get; set; }
    }
}
