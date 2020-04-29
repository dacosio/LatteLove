using LatteLove.Core;
using System.Collections.Generic;
using System.Text;


namespace LatteLove.Datos
{
    public interface ICoffeeData
    {
        IEnumerable<Coffee> GetCoffeeByName(string name);
        Coffee GetById(int Id);
        Coffee Update(Coffee updateCoffee);
        Coffee Add(Coffee newCoffee);
        Coffee Delete(int Id);
        int Commit();
        int GetCountOfCoffee();
    }
}

