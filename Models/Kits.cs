using System.ComponentModel.DataAnnotations;

namespace WorkShop.Models
{
    public class Kits
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Items> Items { get; set; }
        public decimal Price { get; set; }
    }
}
