using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class PaymentProduct
    {
        public int Id { get; set; }

        public int PaymentId { get; set; }

        public virtual Payment Payment { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public double Quantity { get; set; }

        public double Discount { get; set; }
    }
}
