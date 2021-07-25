using HospitalManagementSystem.Shared.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface IRecipesService
    {
        Task<IEnumerable<AllRecipesByUserIdViewModel>> GetAllRecipesByUserIdAsync(string userId);

        Task<IEnumerable<AllRecipesByUserIdViewModel>> GetAllRecipesByDoctorIdAsync(string doctorId);

        Task<RecipeByIdViewModel> GetRecipeById(int id);
    }
}
