using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Expenses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Controllers
{
    public class ExpensesController : ApiController
    {
        private readonly IExpensesService expensesService;

        public ExpensesController(IExpensesService expensesService)
        {
            this.expensesService = expensesService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllExpensesByCreatorIdViewModel>>> GetAllByCreatorId()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<AllExpensesByCreatorIdViewModel> viewModel = await this.expensesService.GetAllByCreatorIdAsync(userId);

            return this.Ok(viewModel);
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<AllExpensesByCreatorIdViewModel>> GetRecentAllByCreatorId()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<AllExpensesByCreatorIdViewModel> viewModel = this.expensesService.GetRecentAllByCreatorIdAsync(userId);

            return this.Ok(viewModel);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<EditExpenseInputModel>> Edit(int id)
        {
            EditExpenseInputModel input = await this.expensesService.GetByIdAsync(id);
            return this.Ok(input);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateExpenseInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(input);
            }

            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            input.CreatorId = userId;
            await this.expensesService.CreateAsync(input);

            return this.Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, EditExpenseInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(input);
            }

            input.Id = id;
            await this.expensesService.UpdateAsync(input);

            return this.Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await this.expensesService.DeleteAsync(id);
            return this.Ok();
        }
    }
}
