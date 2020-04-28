using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LatteLove.Core;
using LatteLove.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LatteLove.Pages.Coffees
{
    public class EditModel : PageModel
    {
        private readonly ICoffeeData coffeeData;
        private readonly IHtmlHelper htmlHelper;

        public EditModel(ICoffeeData coffeeData, IHtmlHelper htmlHelper)
        {
            this.coffeeData = coffeeData;
            this.htmlHelper = htmlHelper;
        }

        public IEnumerable<SelectListItem> CoffeeTypes { get; set; }

        [BindProperty]
        public Coffee Coffee { get; set; }
        public IActionResult OnGet(int Id)
        {
            CoffeeTypes = htmlHelper.GetEnumSelectList<CoffeeType>();

            Coffee = coffeeData.GetById(Id);
            if (Coffee == null)
            {
                return RedirectToPage("NotFound");
            }
            return Page();
        }
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            CoffeeTypes = htmlHelper.GetEnumSelectList<CoffeeType>();
            coffeeData.Update(Coffee);
            coffeeData.Commit();
            return RedirectToPage("CoffeeList");
        }

        
    }
}