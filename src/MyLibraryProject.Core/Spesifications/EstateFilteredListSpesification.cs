using Abp.Specifications;
using MyLibraryProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryProject.Spesifications
{
    public class EstateFilteredListSpesification : Specification<Estate>
    {
        private readonly PropertyType? _propertyType;
        private readonly int? _squareMeter;
        private readonly int? _numberOfRooms;
        private readonly int? _floorLocation;
        private readonly int? _buildingFloor;
        private readonly WarmingType? _warmingType;

        public EstateFilteredListSpesification(PropertyType? propertyType, int? squareMeter, int? numberOfRooms, int? floorLocation, int? buildingFloor, WarmingType? warmingType)
        {
            _propertyType = propertyType;
            _squareMeter = squareMeter;
            _numberOfRooms = numberOfRooms;
            _floorLocation = floorLocation;
            _buildingFloor = buildingFloor;
            _warmingType = warmingType;
        }
        public override Expression<Func<Estate, bool>> ToExpression()
        {
            return (x => (!_propertyType.HasValue || x.PropertyType == _propertyType) &&
            (!_squareMeter.HasValue || x.SquareMeter >= _squareMeter) &&
            (!_numberOfRooms.HasValue || x.NumberOfRooms == _numberOfRooms) &&
            (!_floorLocation.HasValue || x.FloorLocation >= _floorLocation) &&
            (!_buildingFloor.HasValue || x.BuildingFloor >= _buildingFloor) &&
            (!_warmingType.HasValue || x.WarmingType == _warmingType.Value));
        }
    }
}
