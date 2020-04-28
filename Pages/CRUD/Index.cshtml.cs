using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeHolder.Models;

namespace RecipeHolder.Pages.CRUD
{
    public class IndexModel : PageModel
    {
        private readonly RecipeHolder.Models.RecipeHolderContext _context;

        public IndexModel(RecipeHolder.Models.RecipeHolderContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Recipe> Recipe { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CurrentFilter = searchString;

            IQueryable<Recipe> RecipeName = from s in _context.Recipe
                                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                RecipeName = RecipeName.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    RecipeName = RecipeName.OrderByDescending(s => s.Name);
                    break;
                default:
                    RecipeName = RecipeName.OrderBy(s => s.Name);
                    break;
            }

            Recipe = await RecipeName.AsNoTracking().ToListAsync();
        }
    }
}
