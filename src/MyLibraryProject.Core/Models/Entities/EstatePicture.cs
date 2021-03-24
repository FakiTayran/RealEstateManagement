using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryProject.Models.Entities
{
    public class EstatePicture : Entity<int>
    {
        public string ImageUrl { get; set; }

        [ForeignKey("Estate")]
        public int EstateId { get; set; }
        public  Estate Estate { get; set; }
    }
}
