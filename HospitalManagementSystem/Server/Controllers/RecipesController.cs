using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Recipes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Controllers
{
    [Authorize]
    public class RecipesController : ApiController
    {
        private readonly IRecipesService recipesService;

        public RecipesController(IRecipesService recipesService)
        {
            this.recipesService = recipesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllRecipesByUserIdViewModel>>> AllByUserId()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<AllRecipesByUserIdViewModel> viewModel = await this.recipesService.GetAllRecipesByUserIdAsync(userId);

            return this.Ok(viewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeByIdViewModel>> Details(int id)
        {
            RecipeByIdViewModel viewModel = await this.recipesService.GetRecipeById(id);
            return this.Ok(viewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AllRecipesByUserIdViewModel>>> AllByDoctorId(string id)
        {
            IEnumerable<AllRecipesByUserIdViewModel> viewModel = await this.recipesService.GetAllRecipesByDoctorIdAsync(id);
            return this.Ok(viewModel);
        }
    }
}
