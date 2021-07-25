using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class Medicine
    {
        public Medicine()
        {
            this.Recipes = new HashSet<RecipeMedicine>();
        }

        public int Id { get; set; }

        public string MedicineName { get; set; }

        public string GenericName { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public DateTime ExpiryDate { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<RecipeMedicine> Recipes { get; set; }
    }
}
