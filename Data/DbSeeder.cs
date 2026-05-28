using Mahe.Models;

namespace Mahe.Data
{
    public class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(

                    new Product
                    {
                        Name = "Noor",
                        Price = 4500,
                        ImageUrl = "/Images/Noor1.jpeg",
                        Description = "Noor reflects soft purity and timeless grace.The delicately embroided neckline adds a subtle yet elegant detail.Light,breathable and effortlessly refined ---made with love by MAHE",
                        SizeChart="S: Chest:20 Length:32 Shoulders:14.5 " +
                        " M: Chest:20 Length:34 Shoulders:15 " +
                        " L: Chest:21 Length:35 Shoulders:15",
                        Images = new List<ProductImage>
    {
        new ProductImage
        {
            ImageUrl = "/Images/Noor1.jpeg"
        },

        new ProductImage
        {
            ImageUrl = "/Images/Noor2.jpeg"
        },

        new ProductImage
        {
            ImageUrl = "/Images/Noor3.jpeg"
        }
    }
                    },

                    new Product
                    {
                        Name = "Saya",
                        Price = 4500,
                        ImageUrl = "/Images/Saya1.jpeg",
                        Description = "Saya in black is designed for effortless elegance.The delicately embroided neckline adds a refined touch to its timeless black base.Comfortable,graceful,and versatile---a piece made to carry confidence in every step.ONLY at MAHE",
                        SizeChart="S: Chest:20 Length:32 Shoulders:14.5 | M: Chest:20 Length:34 Shoulders:15 | L: Chest:21 Length:35 Shoulders:15",
                        Images = new List<ProductImage>
    {
        new ProductImage
        {
            ImageUrl = "/Images/Saya1.jpeg"
        },

        new ProductImage
        {
            ImageUrl = "/Images/Saya2.jpeg"
        },

        new ProductImage
        {
            ImageUrl = "/Images/Saya3.jpeg"
        }
    }
                    }


                  

                );

                context.SaveChanges();
            }
        }
    }
}