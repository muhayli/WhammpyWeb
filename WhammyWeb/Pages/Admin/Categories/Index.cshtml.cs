using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whammy.DataAccess.Repository.IRepository;
using Whammy.Models;

namespace WhammyWeb.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public IEnumerable<Category> Categories { get; set; }

        public IndexModel(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        public void OnGet()
        {
            Categories = unitOfWork.category.GetAll();
        }
    }
}
