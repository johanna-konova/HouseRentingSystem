using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants.Category;

namespace HouseRentingSystem.Infrastructure.Models
{
    public class Category
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<House> Houses { get; init; } = new HashSet<House>();
    }
}
