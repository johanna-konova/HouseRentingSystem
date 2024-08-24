using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HouseRentingSystem.Infrastructure.Models;

namespace HouseRentingSystem.Infrastructure.Configurations
{
    internal class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasData(GenerateCategories());
        }

        private IEnumerable<Category> GenerateCategories()
        {
            var categories = new HashSet<Category>();

            Category category = new Category()
            {
                Id = 1,
                Name = "Cottage",
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Single-Family",
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Duplex",
            };
            categories.Add(category);

            return categories;
        }
    }
}
