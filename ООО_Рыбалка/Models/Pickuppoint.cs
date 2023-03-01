using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ООО_Рыбалка.Models
{
    public partial class Pickuppoint
    {
        public int IdpickupPoint { get; set; }
        public string Index { get; set; }
        public int City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }

        public virtual Cities CityNavigation { get; set; }
    }
}
