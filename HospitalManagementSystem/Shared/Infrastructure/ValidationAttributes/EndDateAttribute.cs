using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Infrastructure.ValidationAttributes
{
    public class EndDateAttribute : ValidationAttribute
    {
        public EndDateAttribute(string startDate)
        {
            this.StartDate = startDate;
        }

        public string StartDate { get; set; }

        public override bool IsValid(object value)
        {
            if (value is DateTime endDate)
            {
                DateTime startDate = DateTime.Parse(this.StartDate);

                if (endDate < startDate)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
