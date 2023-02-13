using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whammy.DataAccess.Repository.IRepository;
using Whammy.Models;

namespace WhammyWeb.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        public IEnumerable<MenuItem> MenuItems { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<FoodType> FoodTypes { get; set; }

        private readonly IUnitOfWork unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            MenuItems = unitOfWork.menuItem.GetAll(includeProps: "Category,FoodType");
            Categories = unitOfWork.category.GetAll(orderBy: c => c.OrderBy(u => u.DisplayOrder));
        }
    }
}
