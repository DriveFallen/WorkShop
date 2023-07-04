using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkShop.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [Column("ID_Order")]
        public int ID { get; set; }
        [Required]
        public User Client { get; set; }
        public DateTime DateAdd { get; set; } = DateTime.Now;
        public DateTime? DateEnd { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public Status CurentStatus { get; set; } = Status.Await;
        [Column("Buy_Items")]
        public ICollection<Item>? Items { get; set; }
        [Column("Buy_Kits")]
        public ICollection<Kit>? Kits { get; set; }

        public Order()
        {
            Items = new List<Item>();
            CurentStatus = Status.Await;
        }
    }

    public enum Status
    {
        Await,
        Processing,
        Ready,
        Received
    }
}

