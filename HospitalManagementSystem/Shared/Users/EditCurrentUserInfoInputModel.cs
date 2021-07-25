using HospitalManagementSystem.Shared.BloodTypes;
using HospitalManagementSystem.Shared.Infrastructure.ValidationAttributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Users
{
    public class EditCurrentUserInfoInputModel
    {
        public string Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; }

        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int? BloodTypeId { get; set; }

        public IEnumerable<AllBloodTypesDropDownViewModel> BloodTypes { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Address { get; set; }

        public string SecondAddress { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Street { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public string ZipCode { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(40)]
        public string City { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(40)]
        public string Province { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(40)]
        public string State { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string ProfileImageUrl { get; set; }

        public string OtherInfo { get; set; }
    }
}
