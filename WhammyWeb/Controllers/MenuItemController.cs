using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Whammy.DataAccess.Repository.IRepository;
using WhammyWeb.Pages.Admin.MenuItems;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WhammyWeb.Controllers
{
    [Route("api/[controller]")]
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public IWebHostEnvironment WebHostEnvironment { get; }

        public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            WebHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var items = _unitOfWork.menuItem.GetAll(includeProps: "Category,FoodType");
            return Ok(Json(new { data = items }));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var imageManager = new ImageManager(WebHostEnvironment.WebRootPath);
            var item = _unitOfWork.menuItem.GetFirstOrDefault(u => u.Id == id);
            if (item != null)
            {
                imageManager.Delete(item.Image);
                _unitOfWork.menuItem.Remove(item);
                _unitOfWork.Save();
            }
            return Ok(Json(new { success = true, message = "Delete Successful" }));
        }
    }
}

