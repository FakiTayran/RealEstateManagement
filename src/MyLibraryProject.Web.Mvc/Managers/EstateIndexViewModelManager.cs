using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using MyLibraryProject.Models.Entities;
using MyLibraryProject.Spesifications;
using MyLibraryProject.Web.Services;
using MyLibraryProject.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryProject.Web.Managers
{
    public class EstateIndexViewModelManager : IEstateIndexViewModelService
    {
        private readonly IRepository<Estate> _repository;

        public EstateIndexViewModelManager(IRepository<Estate> repository)
        {
            _repository = repository;
        }

        public async Task<EstateIndexViewModel> GetHomeIndexViewModel(PropertyType? propertyType, int? squareMeter, int? numberOfRooms, int? floorLocation, int? buildingFloor, WarmingType? warmingType)
        {
            var spec = new EstateFilteredListSpesification(propertyType, squareMeter, numberOfRooms, floorLocation, buildingFloor, warmingType);

            var filteredEstates =await _repository.GetAllListAsync(spec);

            return new EstateIndexViewModel() 
            {
                Estates = filteredEstates
            };
        }
    }
}
