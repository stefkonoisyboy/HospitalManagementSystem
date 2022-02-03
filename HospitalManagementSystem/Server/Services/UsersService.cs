using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Models;
using HospitalManagementSystem.Server.Models.Enumerations;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared;
using HospitalManagementSystem.Shared.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly Cloudinary cloudinaryUtility;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersService(ApplicationDbContext dbContext, Cloudinary cloudinaryUtility, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.cloudinaryUtility = cloudinaryUtility;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<AllDoctorsViewModel>> GetAllDoctorsAsync()
        {
            return await this.dbContext.Users
                .Where(u => u.Role == "Doctor")
                .OrderBy(u => u.Id)
                .Select(u => new AllDoctorsViewModel
                {
                    Department = u.Department.Name,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    Gender = u.Gender.ToString(),
                    Id = u.Id,
                    LastName = u.LastName,
                    IsActive = u.IsActive,
                    ProfileImageRemoteUrl = u.ProfileImageRemoteUrl,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AllDoctorsDropDownViewModel>> GetAllDoctorsForDropDown()
        {
            return await this.dbContext.Users
                .Where(u => u.Role == GlobalConstants.DoctorRoleName)
                .OrderBy(u => u.FirstName + ' ' + u.LastName)
                .Select(u => new AllDoctorsDropDownViewModel
                {
                    Id = u.Id,
                    FullName = u.FirstName + ' ' + u.LastName,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ReceiversMessageDropDownViewModel>> GetAllUsersForDropDown()
        {
            return await this.dbContext.Users
                .OrderBy(u => u.FirstName + ' ' + u.LastName)
                .Select(u => new ReceiversMessageDropDownViewModel
                {
                    Id = u.Id,
                    FullName = u.FirstName + ' ' + u.LastName,
                })
                .ToListAsync();
        }

        public async Task<CurrentUserViewModel> GetCurrentUserInfoByUsernameAsync(string username)
        {
            return await this.dbContext.Users
                .Where(u => u.UserName == username)
                .Select(u => new CurrentUserViewModel
                {
                    CreatedOn = u.CreatedOn.HasValue ? u.CreatedOn.Value : null,
                    FullName = u.FirstName + ' ' + u.LastName,
                    Role = u.Role,
                    ProfileImageUrl = u.ProfileImageRemoteUrl,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<EditCurrentUserInfoInputModel> GetCurrentUserInfoToBeUpdated(string id)
        {
            return await this.dbContext.Users
                .Where(u => u.Id == id)
                .Select(u => new EditCurrentUserInfoInputModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Gender = u.Gender.ToString(),
                    BloodTypeId = u.BloodTypeId,
                    BirthDate = u.BirthDate,
                    Address = u.Address,
                    SecondAddress = u.SecondAddress,
                    Street = u.Street,
                    ZipCode = u.ZipCode,
                    City = u.City,
                    Province = u.Province,
                    State = u.State,
                    PhoneNumber = u.PhoneNumber,
                    ProfileImageUrl = u.ProfileImageRemoteUrl,
                    OtherInfo = u.OtherInformation,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CurrentUserNavMenuViewModel> GetCurrentUserNavMenuInfoByUsernameAsync(string username)
        {
            return await this.dbContext.Users
                .Where(u => u.UserName == username)
                .Select(u => new CurrentUserNavMenuViewModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    IsActive = u.IsActive,
                    ProfileImageUrl = u.ProfileImageRemoteUrl,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CurrentUserProfileViewModel> GetCurrentUserProfileByIdAsync(string id)
        {
            return await this.dbContext.Users
                .Where(u => u.Id == id)
                .Select(u => new CurrentUserProfileViewModel
                {
                    Address = u.Address,
                    BirthDate = u.BirthDate,
                    BloodType = u.BloodType.Name,
                    City = u.City,
                    Email = u.Email,
                    FullName = u.FirstName + ' ' + u.LastName,
                    OtherInfo = u.OtherInformation,
                    PhoneNumber = u.PhoneNumber,
                })
                .FirstOrDefaultAsync();
        }

        public DashboardViewModel GetDashboardInfoById(string id)
        {
            DashboardViewModel viewModel = new DashboardViewModel
            {
                DoctorsCount = this.dbContext.Users.Count(d => d.Role == GlobalConstants.DoctorRoleName),
                RecipesCount = this.dbContext.Recipes.Count(r => r.PatientId == id),
                PaymentsCount = this.dbContext.Payments.Count(p => p.PatientId == id),
                TreatmentsCount = this.dbContext.Treatments.Count(t => t.PatientId == id),
            };

            return viewModel;
        }

        public async Task<DoctorByIdViewModel> GetDoctorById(string id)
        {
            return await this.dbContext.Users
                .Where(u => u.Id == id)
                .Select(u => new DoctorByIdViewModel
                {
                    Department = u.Department.Name,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    OtherInfo = u.OtherInformation,
                    ProfileImageUrl = u.ProfileImageRemoteUrl,
                })
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id, EditCurrentUserInfoInputModel input)
        {
            ApplicationUser user = await this.dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            user.FirstName = input.FirstName;
            user.LastName = input.LastName;
            user.Gender = (Gender)Enum.Parse(typeof(Gender), input.Gender);
            user.BloodTypeId = input.BloodTypeId;
            user.BirthDate = input.BirthDate;
            user.Address = input.Address;
            user.SecondAddress = input.SecondAddress;
            user.Street = input.Street;
            user.ZipCode = input.ZipCode;
            user.City = input.City;
            user.Province = input.Province;
            user.State = input.State;
            user.PhoneNumber = input.PhoneNumber;
            user.OtherInformation = input.OtherInfo;
            user.ProfileImageRemoteUrl = input.ProfileImageUrl;

            if (input.Password != null)
            {
                string newPassword = this.userManager.PasswordHasher.HashPassword(user, input.Password);
                user.PasswordHash = newPassword;            
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(UpdateUserStatusInputModel input)
        {
            ApplicationUser user = await this.dbContext.Users.FirstOrDefaultAsync(u => u.UserName == input.Username);
            user.IsActive = input.Status;
            await this.dbContext.SaveChangesAsync();
        }
    }
}
