using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seed
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                    new Product
                    {
                        Id = 1,
                        Name = "Kursun Kalem",
                        CategoryId = 1,
                        Price = 100,
                        Stock = 20,
                        CreatedDate = DateTime.Now,
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Tükenmez Kalem",
                        CategoryId = 1,
                        Price = 150,
                        Stock = 8,
                        CreatedDate = DateTime.Now,
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Tutunamayanlar",
                        CategoryId = 2,
                        Price = 99,
                        Stock = 5,
                        CreatedDate = DateTime.Now,
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Çizgili Defter",
                        CategoryId = 3,
                        Price = 199,
                        Stock = 100,
                        CreatedDate = DateTime.Now,
                    }
                );
        }
    }
}
