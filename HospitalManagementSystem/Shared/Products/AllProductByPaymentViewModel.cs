using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Products
{
    public class AllProductByPaymentViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public double Quantity { get; set; }

        public decimal Total => this.Price * (decimal)this.Quantity;

        public double Discount { get; set; }

        public decimal GrandTotal => this.Total - this.Total * ((decimal)this.Discount / 100);
    }
}
