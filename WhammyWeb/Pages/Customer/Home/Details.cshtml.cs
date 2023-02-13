using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whammy.DataAccess.Repository.IRepository;
using Whammy.Models;

namespace WhammyWeb.Pages.Customer.Home
{
    [BindProperties]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;
        public MenuItem MenuItem { get; set; }

        [Range(1, 100, ErrorMessage = "Please select count between 1 and 100")]
        public int Count { get; set; }

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public void OnGet(int id)
        {
            MenuItem = unitOfWork.menuItem.GetFirstOrDefault(m => m.Id == id, includeProps: "Category,FoodType");
        }

    }
}
