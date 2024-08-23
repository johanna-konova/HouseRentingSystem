using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static HouseRentingSystem.Infrastructure.DataConstants.Agent;

namespace HouseRentingSystem.Infrastructure.Models
{
    public class Agent
    {
        public Agent()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; init; }

        [Required]
        [StringLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
    }
}