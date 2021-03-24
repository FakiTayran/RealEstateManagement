using Abp.Domain.Entities;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryProject.Models.Entities
{
    public class Customer:Entity<int>,ICustomValidate,IMustHaveTenant
    {
        public Customer()
        {
            Estates = new HashSet<Estate>(); 
        }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Surname { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 7)]
        public string Phone { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Email { get; set; }
        public string Description { get; set; }

        public  ICollection<Estate> Estates { get; set; }
        public int TenantId { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (string.IsNullOrEmpty(Name))
            {
                context.Results.Add(new ValidationResult("Name is not be empty"));
            }
        }
    }
}
