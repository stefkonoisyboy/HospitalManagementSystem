using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Models;
using HospitalManagementSystem.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Seeders
{
    public class UsersSeeder
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersSeeder(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task SeedAsync()
        {
            if (userManager.Users.Any())
            {
                return;
            }

            ApplicationUser superAdmin = new ApplicationUser
            {
                FirstName = "Stefko",
                LastName = "Tsonyovski",
                Email = "stefko_coniovski@abv.bg",
                UserName = "stefko_coniovski@abv.bg",
                PhoneNumber = "0876148608",
                IsActive = true,
                Role = GlobalConstants.SuperAdministratorRoleName,
            };

            ApplicationUser hospitalAdmin = new ApplicationUser
            {
                FirstName = "Plamen",
                LastName = "Simeonov",
                Email = "plamen_simeonov@abv.bg",
                UserName = "plamen_simeonov@abv.bg",
                PhoneNumber = "1111111111",
                IsActive = true,
                Role = GlobalConstants.HospitalAdministratorRoleName,
                HospitalId = 1,
            };

            ApplicationUser doctor = new ApplicationUser
            {
                FirstName = "Mariana",
                LastName = "Georgieva",
                Email = "mariana_georgieva@abv.bg",
                UserName = "mariana_georgieva@abv.bg",
                PhoneNumber = "1111111111",
                IsActive = true,
                Role = GlobalConstants.DoctorRoleName,
                HospitalId = 1,
            };

            ApplicationUser nurse = new ApplicationUser
            {
                FirstName = "Yuki",
                LastName = "Folsi",
                Email = "yuki_folsi@abv.bg",
                UserName = "yuki_folsi@abv.bg",
                PhoneNumber = "1111111111",
                IsActive = true,
                Role = GlobalConstants.NurseRoleName,
                HospitalId = 1,
            };

            ApplicationUser pharmacist = new ApplicationUser
            {
                FirstName = "Demo",
                LastName = "Pharmacist",
                Email = "demo_pharmacist@abv.bg",
                UserName = "demo_pharmacist@abv.bg",
                PhoneNumber = "1111111111",
                IsActive = true,
                Role = GlobalConstants.PharmacistRoleName,
                HospitalId = 1,
            };

            ApplicationUser laboratory = new ApplicationUser
            {
                FirstName = "Demo",
                LastName = "Laboratory",
                Email = "demo_laboratory@abv.bg",
                UserName = "demo_laboratory@abv.bg",
                PhoneNumber = "1111111111",
                IsActive = true,
                Role = GlobalConstants.LaboratoryRoleName,
                HospitalId = 1,
            };

            ApplicationUser accountant = new ApplicationUser
            {
                FirstName = "Demo",
                LastName = "Accoutant",
                Email = "demo_accountant@abv.bg",
                UserName = "demo_accountant@abv.bg",
                PhoneNumber = "1111111111",
                IsActive = true,
                Role = GlobalConstants.AccountantRoleName,
                HospitalId = 1,
            };

            ApplicationUser patient = new ApplicationUser
            {
                FirstName = "Demo",
                LastName = "Patient",
                Email = "demo_patient@abv.bg",
                UserName = "demo_patient@abv.bg",
                PhoneNumber = "1111111111",
                IsActive = true,
                Role = GlobalConstants.PatientRoleName,
                HospitalId = 1,
            };

            await userManager.CreateAsync(superAdmin, "Djokera03!");
            await userManager.CreateAsync(hospitalAdmin, "Djokera03!");
            await userManager.CreateAsync(doctor, "Djokera03!");
            await userManager.CreateAsync(nurse, "Djokera03!");
            await userManager.CreateAsync(pharmacist, "Djokera03!");
            await userManager.CreateAsync(laboratory, "Djokera03!");
            await userManager.CreateAsync(accountant, "Djokera03!");
            await this.userManager.CreateAsync(patient, "Djokera03!");
        }
    }
}
