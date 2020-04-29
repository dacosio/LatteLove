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
    public class IndexModel : PageModel
    {
        private readonly LatteLove.Datos.ApplicationDbContext _context;

        public IndexModel(LatteLove.Datos.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Coffee> Coffee { get;set; }

        public async Task OnGetAsync()
        {
            Coffee = await _context.Coffee.ToListAsync();
        }
    }
}
