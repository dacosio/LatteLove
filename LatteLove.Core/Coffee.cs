using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LatteLove.Core
{
    public class Coffee
    {
        [Key]
        public int Id { get; set; }
        public double Price { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Location { get; set; }
        public CoffeeType Coffees { get; set; }
    }
}
