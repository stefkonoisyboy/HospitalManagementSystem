using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Infrastructure.ValidationAttributes
{
    public class FileFormatAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is IFormFile image)
            {
                string[] allowedExtensions = new string[] { ".jpg", ".png" };
                string fileExtension = Path.GetExtension(image.FileName);

                if (allowedExtensions.Contains(fileExtension))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
