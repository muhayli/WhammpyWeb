using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whammy.DataAccess.Data;
using Whammy.Models;

namespace WhammyWeb.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public IEnumerable<FoodType> FoodTypes { get; set; }

        public IndexModel(AppDbContext dbContext) => this._dbContext = dbContext;

        public void OnGet()
        {
            FoodTypes = _dbContext.foodTypes;
        }
    }
}
