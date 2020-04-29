using LatteLove.Datos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LatteLove.ViewComponents
{
    public class CoffeeCountViewComponent : ViewComponent
    {
        private readonly ICoffeeData coffeeData;

        public CoffeeCountViewComponent(ICoffeeData coffeeData)
        {
            this.coffeeData = coffeeData;
        }

        public IViewComponentResult Invoke()
        {
            var count = coffeeData.GetCountOfCoffee();
            return View(count);
        }
    }
}
