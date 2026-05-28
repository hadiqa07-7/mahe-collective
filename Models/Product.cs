using System.ComponentModel.DataAnnotations.Schema;

namespace Mahe.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
       

        public string SizeChart { get; set; }
     

        public List<ProductImage> Images { get; set; }
        public int Stock { get; set; }
    }
}