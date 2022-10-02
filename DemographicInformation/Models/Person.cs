using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemographicInformation.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "maximum {1} characters allowed in name.")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "maximum {1} characters allowed in email.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [StringLength(30, ErrorMessage = "maximum {1} characters allowed in phone.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        [StringLength(2500, ErrorMessage = "maximum {1} characters allowed in address.")]
        public string Address { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public int CreatedBy { get; set; }
        
        public DateTime? LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
    }
}