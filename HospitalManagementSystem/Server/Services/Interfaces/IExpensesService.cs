using HospitalManagementSystem.Shared.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface IExpensesService
    {
        Task CreateAsync(CreateExpenseInputModel input);

        Task UpdateAsync(EditExpenseInputModel input);

        Task DeleteAsync(int id);

        Task<EditExpenseInputModel> GetByIdAsync(int id);

        Task<IEnumerable<AllExpensesByCreatorIdViewModel>> GetAllByCreatorIdAsync(string creatorId);

        IEnumerable<AllExpensesByCreatorIdViewModel> GetRecentAllByCreatorIdAsync(string creatorId);
    }
}
