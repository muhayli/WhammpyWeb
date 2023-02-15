using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Whammy.DataAccess.Repository.IRepository;
using Whammy.Models;

namespace WhammyWeb.Pages.Admin.MenuItems
{
    [BindProperties]
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;


        public MenuItem MenuItem { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> FoodTypeList { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            this.unitOfWork = unitOfWork;
            this._hostEnvironment = hostEnvironment;
            MenuItem = new();
        }


        public void OnGet(int? id)
        {
            if (id != null)
            {
                MenuItem = unitOfWork.menuItem.GetFirstOrDefault(m => m.Id == id);
            }

            CategoryList = unitOfWork.category.GetAll().Select(c => new SelectListItem() //for creating dropdown items
            {
                Text = c.Name,
                Value = c.Id.ToString(),
            });
            FoodTypeList = unitOfWork.foodType.GetAll().Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString(),
            });
        }

        public async Task<IActionResult> OnPost()
        {
            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var imageManager = new ImageManager(webRootPath);


            if (MenuItem.Id == 0)
            {
                //create
                MenuItem.Image = imageManager.SetupAndCopy(files);

                unitOfWork.menuItem.Add(MenuItem);
                unitOfWork.Save();
            }
            else
            {
                //update
                var objFromDb = unitOfWork.menuItem.GetFirstOrDefault(o => o.Id == MenuItem.Id);
                if (files.Count > 0)
                {

                    //delete old image
                    imageManager.Delete(objFromDb.Image);
                    MenuItem.Image = imageManager.SetupAndCopy(files);
                }
                else
                {
                    MenuItem.Image = objFromDb.Image;
                }

                unitOfWork.menuItem.Update(MenuItem);
                unitOfWork.Save();
            }

            return RedirectToPage("Index");
        }

    }

    public class ImageManager
    {
        private readonly string _webRootPath;

        public ImageManager(string WebRootPath)
        {
            _webRootPath = WebRootPath;
        }
        public void Delete(string ObjImageFromDb)
        {

            var oldImagePath = Path.Combine(_webRootPath, ObjImageFromDb.TrimStart('\\').Replace('\\', Path.DirectorySeparatorChar)); //replace only for macos from "\" to "/"
            Console.WriteLine(oldImagePath);
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
        }

        public string SetupAndCopy(IFormFileCollection? files)
        {

            string new_fileName = Guid.NewGuid().ToString();
            var uploads = Path.Combine(_webRootPath, "images", "menuItems");
            var extension = Path.GetExtension(files[0].FileName);
            using (var fileStream = new FileStream(Path.Combine(uploads, new_fileName + extension), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }
            return @"\images\menuItems\" + new_fileName + extension;
        }
    }
}
