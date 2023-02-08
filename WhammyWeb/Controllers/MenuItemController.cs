using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Whammy.DataAccess.Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WhammyWeb.Controllers
{
    [Route("api/[controller]")]
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var items = _unitOfWork.menuItem.GetAll(includeProps: "Category,FoodType");
            return Ok(Json(new { data = items }));
        }
    }
}

