using Abp.AspNetCore.Mvc.Authorization;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibraryProject.Authorization;
using MyLibraryProject.Controllers;
using MyLibraryProject.EntityFrameworkCore;
using MyLibraryProject.Models.Entities;
using MyLibraryProject.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryProject.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_EstatePictures)]
    public class EstateImagesController : MyLibraryProjectControllerBase
    {
        private readonly IRepository<Estate> _estateService;
        private readonly IFileUpload _fileUpload;
        private readonly MyLibraryProjectDbContext _myLibraryProjectDbContext;

        public EstateImagesController(IRepository<Estate> estateService, IFileUpload fileUpload, MyLibraryProjectDbContext myLibraryProjectDbContext)
        {
            _estateService = estateService;
            _fileUpload = fileUpload;
            _myLibraryProjectDbContext = myLibraryProjectDbContext;
        }

        public async Task<IActionResult> Upload(int estateId)
        {
            if (estateId == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            var estate = await _myLibraryProjectDbContext.Estates.Include(x => x.Owner).SingleOrDefaultAsync(x=>x.Id == estateId);
            ViewBag.EstateId = estateId;
            ViewBag.EstateIdAndOwnerNameSurname = "Add Picture for ID:#" + estate.Id + " Property (" + estate.Owner.Name + " " + estate.Owner.Surname + " )";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile[] file, int estateId)  //Defined word "file" in dropzone
        {
            if (estateId != 0)
            {
                var estate = await _estateService.FirstOrDefaultAsync(x => x.Id == estateId);
                if (estate == null)
                {
                    return NotFound();
                }
                if (file.Length > 0)
                {
                    foreach (var item in file)
                    {
                        var result = _fileUpload.Upload(item);
                        if (result.FileResult == Utilities.FileResult.Succeded)
                        {
                            EstatePicture estatePicture = new EstatePicture();
                            estatePicture.ImageUrl = result.FileUrl;
                            estatePicture.EstateId = estate.Id;
                            estate.EstatePictures.Add(estatePicture);
                            await _myLibraryProjectDbContext.SaveChangesAsync();
                        }
                    }
                }
            }

            return View();
        }
    }
}

