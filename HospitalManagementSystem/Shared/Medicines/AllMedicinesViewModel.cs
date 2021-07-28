using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Medicines
{
    public class AllMedicinesViewModel
    {
        public int Id { get; set; }

        public string MedicineName { get; set; }

        public string GenericName { get; set; }

        public string Category { get; set; }

        public DateTime ExpiryDate { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
