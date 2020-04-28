using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LatteLove.Core;
using LatteLove.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LatteLove.Pages.Coffees
{
    public class DetailModel : PageModel
    {
        private readonly ICoffeeData coffeedata;

        [TempData]
        public string Message { get; set; }
        public DetailModel(ICoffeeData coffeedata)
        {
            this.coffeedata = coffeedata;
        }
        public Coffee Coffee { get; set; }
        public IActionResult OnGet(int Id)
        {
            Coffee = coffeedata.GetById(Id);

            if (Coffee == null)
            {
                return RedirectToPage("NotFound");
            }
            
            return Page();
        }
    }
}