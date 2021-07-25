using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Payments
{
    public class AllPaymentsByUserIdViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Doctor { get; set; }

        public DateTime Date { get; set; }

        public decimal Total { get; set; }
    }
}
