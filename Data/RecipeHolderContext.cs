using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RecipeHolder.Models
{
    public class RecipeHolderContext : DbContext
    {
        public RecipeHolderContext (DbContextOptions<RecipeHolderContext> options)
            : base(options)
        {
        }

        public DbSet<RecipeHolder.Models.Recipe> Recipe { get; set; }
    }
}
