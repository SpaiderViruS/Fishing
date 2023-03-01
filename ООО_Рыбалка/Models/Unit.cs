using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ООО_Рыбалка.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Product = new HashSet<Product>();
        }

        public int IdUnit { get; set; }
        public string UnitName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
