using System.ComponentModel.DataAnnotations;

namespace WorkShop.Models
{
    public class Clients
    {
        [Key]
        public int ID { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FIO { get; set;}
    }
}
