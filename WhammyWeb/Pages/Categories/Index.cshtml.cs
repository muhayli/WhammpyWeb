using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhammyWeb.Data;
using WhammyWeb.Models;

namespace WhammyWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public IEnumerable<Category> Categories { get; set; }

        public IndexModel(AppDbContext dbContext) => this._dbContext = dbContext;

        public  void OnGet()
        {
            Categories = _dbContext.categories;
        }
    }
}
