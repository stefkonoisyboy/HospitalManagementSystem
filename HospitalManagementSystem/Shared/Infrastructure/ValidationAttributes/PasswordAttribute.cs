using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Infrastructure.ValidationAttributes
{
    public class PasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string passWord)
            {
                int validConditions = 0;

                foreach (char c in passWord)
                {
                    if (c >= 'a' && c <= 'z')
                    {
                        validConditions++;
                        break;
                    }
                }
                foreach (char c in passWord)
                {
                    if (c >= 'A' && c <= 'Z')
                    {
                        validConditions++;
                        break;
                    }
                }
                if (validConditions == 0) return false;
                foreach (char c in passWord)
                {
                    if (c >= '0' && c <= '9')
                    {
                        validConditions++;
                        break;
                    }
                }
                if (validConditions == 1) return false;
                if (validConditions == 2)
                {
                    char[] special = { '@', '#', '$', '%', '^', '&', '+', '=' }; // or whatever    
                    if (passWord.IndexOfAny(special) == -1) return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
