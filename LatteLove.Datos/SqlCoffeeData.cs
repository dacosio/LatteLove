using LatteLove.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LatteLove.Datos
{
    public class SqlCoffeeData : ICoffeeData
    {
        private readonly ApplicationDbContext db;

        public SqlCoffeeData(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Coffee Add(Coffee newCoffee)
        {
            db.Add(newCoffee);
            return newCoffee;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Coffee Delete(int Id)
        {
            var coffeeShop = GetById(Id);
            if (coffeeShop != null)
            {
                db.Coffee.Remove(coffeeShop);
            }

            return coffeeShop;
        }

        public Coffee GetById(int Id)
        {
            return db.Coffee.Find(Id);
        }

        public IEnumerable<Coffee> GetCoffeeByName(string name)
        {
            var query = from c in db.Coffee
                        where c.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby c.Name
                        select c;

            return query;
        }

        public int GetCountOfCoffee()
        {
            return db.Coffee.Count();
        }

        public Coffee Update(Coffee updateCoffee)
        {
            var entity = db.Coffee.Attach(updateCoffee);
            entity.State = EntityState.Modified;
            return updateCoffee;
        }
    }
}

