using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whammy.DataAccess.Data;
using Whammy.DataAccess.Repository.IRepository;
using Whammy.Models;

namespace WhammyWeb.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public IEnumerable<FoodType> FoodTypes { get; set; }

        public IndexModel(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        public void OnGet()
        {
            FoodTypes = unitOfWork.foodType.GetAll();
        }
    }
}
