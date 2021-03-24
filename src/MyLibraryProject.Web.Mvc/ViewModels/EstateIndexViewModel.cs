using MyLibraryProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryProject.Web.ViewModels
{
    public class EstateIndexViewModel
    {
        public List<Estate> Estates { get; set; }

        public PropertyType? PropertyType { get; set; }
        public int? SquareMeter { get; set; }
        public int? NumberOfRooms { get; set; }
        public int? FloorLocation { get; set; }
        public int? BuildingFloor { get; set; }
        public WarmingType? WarmingType { get; set; }
    }
}
