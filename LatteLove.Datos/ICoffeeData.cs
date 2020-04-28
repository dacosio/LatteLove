using LatteLove.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;


namespace LatteLove.Datos
{
    public interface ICoffeeData
    {
        IEnumerable<Coffee> GetCoffeeByName(string name);
        Coffee GetById(int Id);
        Coffee Update(Coffee updateCoffee);
        Coffee Add(Coffee newCoffee);
        int Commit();
    }

    public class InMemoryCoffeeData : ICoffeeData
    {
        readonly List<Coffee> coffee;

        public InMemoryCoffeeData()
        {
            coffee = new List<Coffee>()
            {
                new Coffee{Id=1, Location="SM Clark, Pampanga", Name = "Coffee Bean & Tea Leaf", Coffees=CoffeeType.Affogato, Price=2.85},
                new Coffee{Id=2, Location="Marquee Mall, Pampanga", Name = "Coffee Bean & Tea Leaf",Coffees=CoffeeType.Americano, Price=1.85},
                new Coffee{Id=3, Location="Northwalk Clark, Pampanga", Name = "Coffee Bean & Tea Leaf", Coffees=CoffeeType.Brewed, Price=2.75},
                new Coffee{Id=4, Location="Bertaphil Clark, Pampanga", Name = "Starbucks", Coffees=CoffeeType.Espresso, Price=1.50},
                new Coffee{Id=5, Location="Balibago, Pampanga", Name = "Starbucks", Coffees=CoffeeType.Latte, Price=3.00},
                new Coffee{Id=6, Location="SM Clark, Pampanga", Name = "Starbucks", Coffees=CoffeeType.Macchiato, Price=4.25},
                new Coffee{Id=7, Location="Mabalacat, Pampanga", Name = "Coffee Artisan", Coffees=CoffeeType.Marocchino, Price=1.80},
                new Coffee{Id=8, Location="Balibago, Pampanga", Name = "Coffee Artisan", Coffees=CoffeeType.Mocha, Price=2.20},
                new Coffee{Id=9, Location="Porac, Pampanga", Name = "Coffee Artisan", Coffees=CoffeeType.Ristretto, Price=3.99}
            };
        }

        public Coffee Add(Coffee newCoffee)
        {
            coffee.Add(newCoffee);
            newCoffee.Id = coffee.Max(r => r.Id) + 1;
            return newCoffee;
        }

        public int Commit()
        {
            return 0;
        }

        public Coffee GetById(int Id)
        {
            return coffee.SingleOrDefault(r => r.Id == Id);
        }

        public IEnumerable<Coffee> GetCoffeeByName(string name = null)
        {
            return from c in coffee
                   where string.IsNullOrEmpty(name) || c.Name.StartsWith(name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name))
                   orderby c.Name
                   select c;
        }

        public Coffee Update(Coffee updateCoffee)
        {
            var kape = coffee.SingleOrDefault(r => r.Id == updateCoffee.Id);
            if (kape != null)
            {
                kape.Name = updateCoffee.Name;
                kape.Location = updateCoffee.Location;
                kape.Coffees = updateCoffee.Coffees;
            }

            return kape;
        }
    }
}
