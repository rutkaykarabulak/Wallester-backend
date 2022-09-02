using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Wallester.Api.CommonTypes;

namespace Wallester.Api.EFModels
{
    [Table("Customer")]
    public class Customer
    {
        [Key, Required]
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; } = String.Empty;

        [MaxLength(100)]
        public string LastName { get; set; } = String.Empty;
        public string FullName { get; set; } = String.Empty;
        public DateTime BirthDate { get; set; }

        [Required]
        public GenderType Gender { get; set; }

        public string Email { get; set; } = String.Empty;

        [MaxLength(200)]
        public string Address { get; set; } = String.Empty;

        public DateTime DateCreated { get; set; }

        [MaxLength(50)]
        public string CountryOfBirth { get; set; } = String.Empty;

        public TitleType Title { get; set; }

        public MarialStatus MarialStatus { get; set; }

        public EmploymentStatus EmploymentStatus { get; set; }

        public CustomerType Type { get; set; }
    }
}
