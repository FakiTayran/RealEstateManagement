using Abp.AspNetCore.Mvc.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibraryProject.Authorization;
using MyLibraryProject.Controllers;
using MyLibraryProject.EntityFrameworkCore;
using MyLibraryProject.Models.Entities;
using MyLibraryProject.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryProject.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Estates)]

    public class EstateController : MyLibraryProjectControllerBase
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Estate> _estateRepository;
        private readonly IEstateIndexViewModelService _estateIndexViewModelService;
        private readonly MyLibraryProjectDbContext _myLibraryProjectDbContext;

        public EstateController(IRepository<Customer> customerRepository,IRepository<Estate> estateRepository,IEstateIndexViewModelService estateIndexViewModelService,MyLibraryProjectDbContext myLibraryProjectDbContext)
        {
            _customerRepository = customerRepository;
            _estateRepository = estateRepository;
            _estateIndexViewModelService = estateIndexViewModelService;
            _myLibraryProjectDbContext = myLibraryProjectDbContext;
        }
        [DisableValidation]
        public async Task<IActionResult> Index(PropertyType? propertyType, int? squareMeter, int? numberOfRooms, int? floorLocation, int? buildingFloor, WarmingType? warmingType)
        {
            return View(await _estateIndexViewModelService.GetHomeIndexViewModel(propertyType, squareMeter, numberOfRooms, floorLocation, buildingFloor, warmingType));
        }

        public IActionResult Add(int customerId) 
        {
            var customer = _customerRepository.FirstOrDefault(x => x.Id == customerId);
            ViewBag.customerNameSurname = customer.Name + " " + customer.Surname;
            ViewBag.customerId = customer.Id;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Estate estate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = _customerRepository.FirstOrDefault(x => x.Id == estate.OwnerId);
            estate.Owner = customer;
            _estateRepository.Insert(estate);
            customer.Estates.Add(estate);
            _myLibraryProjectDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            Estate estate = await _myLibraryProjectDbContext.Estates.Include(x => x.EstatePictures).Include(x => x.Owner).SingleOrDefaultAsync(x => x.Id == id);
            return View(estate);
        }
    }
}
