using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Models;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Expenses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly ApplicationDbContext dbContext;

        public ExpensesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(CreateExpenseInputModel input)
        {
            Expense expense = new Expense
            {
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
                CreatorId = input.CreatorId,
                CreatedOn = DateTime.UtcNow,
            };

            await this.dbContext.Expenses.AddAsync(expense);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Expense expense = await this.dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);
            this.dbContext.Expenses.Remove(expense);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllExpensesByCreatorIdViewModel>> GetAllByCreatorIdAsync(string creatorId)
        {
            return await this.dbContext.Expenses
                .Where(e => e.CreatorId == creatorId)
                .OrderBy(e => e.Id)
                .Select(e => new AllExpensesByCreatorIdViewModel
                {
                    Id = e.Id,
                    Description = e.Description,
                    Name = e.Name,
                    Price = e.Price,
                })
                .ToListAsync();
        }

        public async Task<EditExpenseInputModel> GetByIdAsync(int id)
        {
            return await this.dbContext.Expenses
                .Where(e => e.Id == id)
                .Select(e => new EditExpenseInputModel
                {
                    Id = e.Id,
                    CreatorId = e.CreatorId,
                    Description = e.Description,
                    Name = e.Name,
                    Price = e.Price,
                })
                .FirstOrDefaultAsync();
        }

        public IEnumerable<AllExpensesByCreatorIdViewModel> GetRecentAllByCreatorIdAsync(string creatorId)
        {
            IEnumerable<Expense> expenses = this.dbContext.Expenses.Where(e => e.CreatorId == creatorId).ToList();
            ICollection<AllExpensesByCreatorIdViewModel> result = new List<AllExpensesByCreatorIdViewModel>();

            foreach (var expense in expenses)
            {
                int difference = (int)((DateTime.UtcNow - expense.CreatedOn).TotalHours);

                if (difference <= 24)
                {
                    AllExpensesByCreatorIdViewModel viewModel = new AllExpensesByCreatorIdViewModel
                    {
                        Id = expense.Id,
                        Name = expense.Name,
                    };

                    result.Add(viewModel);
                }
            }

            return result.ToList();
        }

        public async Task UpdateAsync(EditExpenseInputModel input)
        {
            Expense expense = await this.dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == input.Id);

            expense.Name = input.Name;
            expense.Description = input.Description;
            expense.Price = input.Price;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
