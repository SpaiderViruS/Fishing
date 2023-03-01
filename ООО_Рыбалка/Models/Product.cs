using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ООО_Рыбалка.Models
{
    public partial class Product
    {
        public Product()
        {
            Orderproduct = new HashSet<Orderproduct>();
        }

        public string ProductArticleNumber { get; set; }
        public string ProductName { get; set; }
        public int ProductCategory { get; set; }
        public int ProductManufacturer { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPhoto { get; set; }
        public int ProductSupplier { get; set; }
        public int ProductUnit { get; set; }
        public decimal ProductCost { get; set; }
        public sbyte? ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public sbyte ProductDiscountMax { get; set; }

        public virtual Category ProductCategoryNavigation { get; set; }
        public virtual Manufacturer ProductManufacturerNavigation { get; set; }
        public virtual Supplier ProductSupplierNavigation { get; set; }
        public virtual Unit ProductUnitNavigation { get; set; }
        public virtual ICollection<Orderproduct> Orderproduct { get; set; }
    }
}
