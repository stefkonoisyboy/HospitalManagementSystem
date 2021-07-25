using CMS.Membership;
using CMS.SiteProvider;
using HospitalManagementSystem.Server.Models;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared;
using HospitalManagementSystem.Shared.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        private readonly IUsersService usersService;
        private readonly IBloodTypesService bloodTypesService;

        public UsersController(IUsersService usersService, IBloodTypesService bloodTypesService)
        {
            this.usersService = usersService;
            this.bloodTypesService = bloodTypesService;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<CurrentUserViewModel>> GetCurrentUser(string username)
        {
            CurrentUserViewModel viewModel = await this.usersService.GetCurrentUserInfoByUsernameAsync(username);
            return viewModel;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<CurrentUserNavMenuViewModel>> GetCurrentUserNavMenu(string username)
        {
            CurrentUserNavMenuViewModel viewModel = await this.usersService.GetCurrentUserNavMenuInfoByUsernameAsync(username);
            return this.Ok(viewModel);
        }

        [HttpGet]
        public async Task<CurrentUserProfileViewModel> GetProfileInfo()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            CurrentUserProfileViewModel viewModel = await this.usersService.GetCurrentUserProfileByIdAsync(userId);
            return viewModel;
        }

        [HttpGet]
        public ActionResult<DashboardViewModel> GetCurrentUserDashboardInfo()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            DashboardViewModel viewModel = this.usersService.GetDashboardInfoById(userId);
            return this.Ok(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllDoctorsViewModel>>> GetAllDoctors()
        {
            IEnumerable<AllDoctorsViewModel> viewModel = await this.usersService.GetAllDoctorsAsync();
            return this.Ok(viewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorByIdViewModel>> GetDoctorById(string id)
        {
            DoctorByIdViewModel viewModel = await this.usersService.GetDoctorById(id);
            return this.Ok(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult<EditCurrentUserInfoInputModel>> Edit()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            EditCurrentUserInfoInputModel input = await this.usersService.GetCurrentUserInfoToBeUpdated(userId);
            input.BloodTypes = await this.bloodTypesService.GetAllBloodTypes();
            return this.Ok(input);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditCurrentUserInfoInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.BloodTypes = await this.bloodTypesService.GetAllBloodTypes();
                return this.BadRequest(input);
            }

            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.usersService.UpdateAsync(userId, input);

            return this.Ok();
        }

        [HttpPut]
        public async Task<ActionResult> ChangeUserStatus(UpdateUserStatusInputModel input)
        {
            await this.usersService.UpdateStatusAsync(input);
            return this.Ok();
        }
    }
}
