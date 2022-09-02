using static Wallester.Api.CommonTypes;
using System.ComponentModel.DataAnnotations;

namespace Wallester.Api.DbModels
{
    public class Customer
    {
        /// <summary>
        /// Id of the customer
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// First name of customer
        /// </summary>
        public string FirstName { get; set; } = String.Empty;
        /// <summary>
        /// Last name of customer
        /// </summary>
        public string LastName { get; set; } = String.Empty;
        /// <summary>
        /// First name + last name of customer
        /// </summary>
        public string FullName { get; set; } = String.Empty;
        /// <summary>
        /// Date of birth of customer
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Genter of customer
        /// </summary>
        public GenderType Gender { get; set; }
        /// <summary>
        /// Email address of customer
        /// </summary>
        public string Email { get; set; } = String.Empty;
        /// <summary>
        /// Full address of customer
        /// </summary>
        public string Address { get; set; } = String.Empty;
        /// <summary>
        /// Creation date of record
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Place of birth
        /// </summary>
        public string CountryOfBirth { get; set; } = String.Empty;
        /// <summary>
        /// Tite of customer
        /// </summary>
        public TitleType Title { get; set; }
        /// <summary>
        /// Marial status of customer
        /// </summary>
        public MarialStatus MarialStatus { get; set; }
        /// <summary>
        /// Employee status of customer
        /// </summary>
        public EmploymentStatus EmploymentStatus { get; set; }
        /// <summary>
        /// Type of customer
        /// </summary>
        public CustomerType Type { get; set; }
    }
}
