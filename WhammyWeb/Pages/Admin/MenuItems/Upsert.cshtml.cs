using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Whammy.DataAccess.Data;
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


        public void OnGet()
        {
            CategoryList = unitOfWork.category.GetAll().Select(c => new SelectListItem()
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
            if (MenuItem.Id == 0)
            {
                //create
                string new_fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, "images", "menuItems");
                var extension = Path.GetExtension(files[0].FileName);
                Console.WriteLine(uploads);
                using (var fileStream = new FileStream(Path.Combine(uploads, new_fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                MenuItem.Image = @"\images\menuItems\" + new_fileName + extension;
                unitOfWork.menuItem.Add(MenuItem);
                unitOfWork.Save();
            }
            else
            {
                //update
            }
            return Page();
        }
    }
}
