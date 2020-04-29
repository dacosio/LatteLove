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
    public class DeleteModel : PageModel
    {
        private readonly ICoffeeData coffeeData;
        public DeleteModel(ICoffeeData coffeeData)
        {
            this.coffeeData = coffeeData;
        }

        public Coffee Coffee { get; set; }

        public IActionResult OnGet(int Id)
        {
            Coffee = coffeeData.GetById(Id);
            if (Coffee == null)
            {
                return RedirectToPage("NotFound");
            }

            return Page();

        }

        public IActionResult OnPost(int Id)
        {
            var kape = coffeeData.Delete(Id);
            coffeeData.Commit();

            if (kape == null)
            {
                return RedirectToPage("NotFound");
            }

            TempData["Message"] = $"{ kape.Name} deleted";
            return RedirectToPage("CoffeeList");
        }
    }
}