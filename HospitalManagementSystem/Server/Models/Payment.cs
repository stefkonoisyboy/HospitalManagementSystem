using HospitalManagementSystem.Server.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class Payment
    {
        public Payment()
        {
            this.Products = new HashSet<PaymentProduct>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string OtherInformation { get; set; }

        public string DoctorId { get; set; }

        public virtual ApplicationUser Doctor { get; set; }

        public string PatientId { get; set; }

        public virtual ApplicationUser Patient { get; set; }

        public DateTime Date { get; set; }

        public DateTime DueDate { get; set; }

        public decimal Total => this.Products.Sum(p => p.Product.Price * (decimal)p.Quantity - (p.Product.Price * (decimal)p.Quantity) * ((decimal)p.Discount / 100));

        public PaymentStatus Status { get; set; }

        public virtual ICollection<PaymentProduct> Products { get; set; }
    }
}
