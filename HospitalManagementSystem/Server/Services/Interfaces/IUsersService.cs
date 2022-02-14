using HospitalManagementSystem.Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface IUsersService
    {
        Task UpdateAsync(string id, EditCurrentUserInfoInputModel input);

        Task UpdateStatusAsync(UpdateUserStatusInputModel input);

        Task<EditCurrentUserInfoInputModel> GetCurrentUserInfoToBeUpdated(string id);

        Task<CurrentUserViewModel> GetCurrentUserInfoByUsernameAsync(string username);

        Task<CurrentUserNavMenuViewModel> GetCurrentUserNavMenuInfoByUsernameAsync(string username);

        Task<CurrentUserProfileViewModel> GetCurrentUserProfileByIdAsync(string id);

        DashboardViewModel GetDashboardInfoById(string id);

        Task<DoctorByIdViewModel> GetDoctorById(string id);

        Task<IEnumerable<AllDoctorsViewModel>> GetAllDoctorsAsync();

        Task<IEnumerable<ReceiversMessageDropDownViewModel>> GetAllUsersForDropDown();

        Task<IEnumerable<AllDoctorsDropDownViewModel>> GetAllDoctorsForDropDown();

        Task<IEnumerable<AllPatientsDropDownViewModel>> GetAllPatientsForDropDown();
    }
}
