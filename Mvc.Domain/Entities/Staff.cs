using System.ComponentModel.DataAnnotations;

namespace Mvc.Domain.Entities
{
    public class Staff
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Staff Name")]
        public string Name { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
    }
}
