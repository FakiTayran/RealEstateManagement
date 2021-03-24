using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryProject.Models.Entities
{
    public class Estate : Entity<int>,ICustomValidate, IMustHaveTenant
    {
        public Estate()
        {
            EstatePictures = new HashSet<EstatePicture>();
        }
        [Required]
        [Display(Name = "Property Type")]
        public PropertyType PropertyType { get; set; }

        //try  custom validate 
        [Display(Name = "Square Meter")]

        public int SquareMeter { get; set; }
        [Required]
        [Range(1, 10)]
        [Display(Name = "Number Of Rooms")]

        public int NumberOfRooms { get; set; }
        [Required]
        [Range(-4, 46)]
        [Display(Name = "Floor Location")]

        public int FloorLocation { get; set; }
        [Required]
        [Range(1, 50)]
        [Display(Name = "Building Floor")]

        public int BuildingFloor { get; set; }
        [Required]
        [Display(Name = "Warming Type")]
        public WarmingType WarmingType { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public  Customer Owner { get; set; }

        public  ICollection<EstatePicture> EstatePictures { get; set; }
        public int TenantId { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (SquareMeter < 10 || SquareMeter > 1000)
            {
                context.Results.Add(new ValidationResult("Square meter should be between 10 and 1000"));
            }
        }
    }

    public enum PropertyType
    {
        [Display(Name = "For Sale")]
        ForSale = 0,
        [Display(Name = "For Rent")]
        ForRent = 1,
        [Display(Name = "Daily Rent")]
        DailyRent = 2
    }

    public enum WarmingType
    {
        None = 0,
        Stove = 1,
        Heater = 2,
        Central = 3
    }
}

