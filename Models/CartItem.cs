using System.ComponentModel.DataAnnotations.Schema;
namespace Mahe.Models
{
    [NotMapped]
    public class CartItem
    {
        public Product Product { get; set; }

        public string Size { get; set; }

        public int Quantity { get; set; }
    }
}