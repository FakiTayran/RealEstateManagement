using Abp.AspNetCore.Mvc.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Validation;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using MyLibraryProject.Authorization;
using MyLibraryProject.Controllers;
using MyLibraryProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryProject.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Customers)]
    public class CustomerController : MyLibraryProjectControllerBase
    {
        private readonly IRepository<Customer,int> _repository;

        public CustomerController(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var customers = _repository.GetAllList();
            return View(customers);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Insert(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int customerId)
        {
            if (customerId == 0 )
            {
                throw new UserFriendlyException(L("Something went wrong..."));
            }

            var customer = _repository.FirstOrDefault(x => x.Id == customerId);

            _repository.Delete(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int customerId)
        {
            var customer = _repository.FirstOrDefault(x => x.Id == customerId);
            return View(customer);
        }

        [HttpPost]
        [DisableValidation]

        public async Task<IActionResult> Edit(Customer customer)
        {
            await _repository.UpdateAsync(customer);
            return RedirectToAction("Index");
        }

    }
}
