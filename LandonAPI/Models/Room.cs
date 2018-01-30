using LandonAPI.Infrastructure;

namespace LandonAPI.Models
{
    public class Room : Resource
    {
        [Sortable]
        [Searchable]
        public string Name { get; set; }

        [Sortable(Default = true)]
        [SearchableDecimal]
        public decimal Rate { get; set; }

        public Form Book { get; set; }
    }
}
