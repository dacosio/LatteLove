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
        private readonly IHtmlHelper htmlHelper; //this is for asp-item

        public EditModel(ICoffeeData coffeeData, IHtmlHelper htmlHelper)
        {
            this.coffeeData = coffeeData;
            this.htmlHelper = htmlHelper;
        }

        public IEnumerable<SelectListItem> CoffeeTypes { get; set; } //this is for asp-item

        [BindProperty]
        public Coffee Coffee { get; set; }
        public IActionResult OnGet(int? Id)
        {
            CoffeeTypes = htmlHelper.GetEnumSelectList<CoffeeType>();

            if (Id.HasValue)
            {
                Coffee = coffeeData.GetById(Id.Value);
            }
            else
            {
                Coffee = new Coffee();
            }

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
                CoffeeTypes = htmlHelper.GetEnumSelectList<CoffeeType>();
                return Page();
            }

            if (Coffee.Id > 0)
            {
                coffeeData.Update(Coffee);
            }
            else
            {
                coffeeData.Add(Coffee);
            }

            coffeeData.Commit();
            TempData["Message"] = "Coffee Shop Saved";
            return RedirectToPage("Detail", new { Id = Coffee.Id });
        }

        
    }
}