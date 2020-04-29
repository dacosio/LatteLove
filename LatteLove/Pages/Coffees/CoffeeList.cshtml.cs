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
    public class CoffeeListModel : PageModel
    {
        private readonly ICoffeeData coffeeData;
        public CoffeeListModel(ICoffeeData coffee)
        {
            coffeeData = coffee;
        }
        public IEnumerable<Coffee> Coffee { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchName { get; set; }
       
        public void OnGet()
        {
            Coffee = coffeeData.GetCoffeeByName(SearchName);
        }
    }
}