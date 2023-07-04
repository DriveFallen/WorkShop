using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkShop.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        [Column("ID_Item")]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; } = 0;
        [Column("Image")]
        public string? Photo { get; set; }
        [ForeignKey("ID_Kit")]
        [Column("ID_Kit")]
        [Required]
        public ICollection<Kit>? kits { get; set; }
        [Column("Buy_Items")]
        public ICollection<Order>? Orders { get; set; }
        [NotMapped]
        public IFormFile imagePath { get; set; }
    }
}
