using HospitalManagementSystem.Server.Models.Enumerations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.TreatmentsCreated = new HashSet<Treatment>();
            this.TreatmentsReceived = new HashSet<Treatment>();
            this.RecipesCreated = new HashSet<Recipe>();
            this.RecipesReceived = new HashSet<Recipe>();
            this.PaymentsCreated = new HashSet<Payment>();
            this.PaymentsReceived = new HashSet<Payment>();
            this.Documentations = new HashSet<Documentation>();
            this.MessagesCreated = new HashSet<Message>();
            this.MessagesReceived = new HashSet<UserMessage>();
            this.Appointments = new HashSet<Appointment>();
            this.AppointmentsSupervised = new HashSet<Appointment>();
            this.AppointmentsCreated = new HashSet<Appointment>();
            this.BlogPosts = new HashSet<BlogPost>();
            this.SmsMessages = new HashSet<SmsMessage>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Role { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public string State { get; set; }

        public string Province { get; set; }

        public string ProfileImageRemoteUrl { get; set; }

        public string LabelClass { get; set; }

        public bool IsActive { get; set; }

        public int? HospitalId { get; set; }

        public virtual Hospital Hospital { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string Address { get; set; }

        public string SecondAddress { get; set; }

        public string City { get; set; }

        public int? BloodTypeId { get; set; }

        public virtual BloodType BloodType { get; set; }

        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public string OtherInformation { get; set; }

        public Gender Gender { get; set; }

        public virtual ICollection<Treatment> TreatmentsCreated { get; set; }

        public virtual ICollection<Treatment> TreatmentsReceived { get; set; }

        public virtual ICollection<Recipe> RecipesCreated { get; set; }

        public virtual ICollection<Recipe> RecipesReceived { get; set; }

        public virtual ICollection<Payment> PaymentsCreated { get; set; }

        public virtual ICollection<Payment> PaymentsReceived { get; set; }

        public virtual ICollection<Documentation> Documentations { get; set; }

        public virtual ICollection<Message> MessagesCreated { get; set; }

        public virtual ICollection<UserMessage> MessagesReceived { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

        public virtual ICollection<Appointment> AppointmentsSupervised { get; set; }

        public virtual ICollection<Appointment> AppointmentsCreated { get; set; }

        public virtual ICollection<BlogPost> BlogPosts { get; set; }

        public virtual ICollection<SmsMessage> SmsMessages { get; set; }
    }
}
