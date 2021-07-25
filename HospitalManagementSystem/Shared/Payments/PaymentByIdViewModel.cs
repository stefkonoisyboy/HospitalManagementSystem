using HospitalManagementSystem.Shared.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Payments
{
    public class PaymentByIdViewModel
    {
        public PaymentByIdViewModel()
        {
            this.Products = new List<AllProductByPaymentViewModel>();
        }

        public int Id { get; set; }

        public string PatientAddress { get; set; }

        public string PatientCity { get; set; }

        public string PatientEmail { get; set; }

        public string PatientPhone { get; set; }

        public string PatientState { get; set; }

        public string Patient { get; set; }

        public DateTime Date { get; set; }

        public DateTime DueDate { get; set; }

        public string OtherInfo { get; set; }

        public int Status { get; set; }

        public IEnumerable<AllProductByPaymentViewModel> Products { get; set; }
    }
}
