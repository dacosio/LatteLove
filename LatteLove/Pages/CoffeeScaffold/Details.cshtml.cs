using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LatteLove.Core;
using LatteLove.Datos;

namespace LatteLove.Pages.CoffeeScaffold
{
    public class DetailsModel : PageModel
    {
        private readonly LatteLove.Datos.ApplicationDbContext _context;

        public DetailsModel(LatteLove.Datos.ApplicationDbContext context)
        {
            _context = context;
        }

        public Coffee Coffee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Coffee = await _context.Coffee.FirstOrDefaultAsync(m => m.Id == id);

            if (Coffee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
