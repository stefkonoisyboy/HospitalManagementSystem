using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class Product
    {
        public Product()
        {
            this.Payments = new HashSet<PaymentProduct>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<PaymentProduct> Payments { get; set; }
    }
}
