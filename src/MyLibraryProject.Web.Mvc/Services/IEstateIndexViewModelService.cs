using MyLibraryProject.Models.Entities;
using MyLibraryProject.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryProject.Web.Services
{
    public interface IEstateIndexViewModelService
    {
        Task<EstateIndexViewModel> GetHomeIndexViewModel(PropertyType? propertyType, int? squareMeter, int? numberOfRooms, int? floorLocation, int? buildingFloor, WarmingType? warmingType);

    }
}
