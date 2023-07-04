using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkShop.Models
{
    [Table("Kits")]
    public class Kit
    {
        [Key]
        [Column("ID_Kit")]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        [Column("Image")]
        public string? Photo { get; set; }
        [ForeignKey("ID_Item")]
        [Column("ID_Item")]
        [Required]
        public ICollection<Item> Items { get; set; }
        [Column("Buy_Items")]
        public ICollection<Order>? Orders { get; set; }
        [NotMapped]
        public IFormFile imagePath { get; set; }
    }
}
