using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Documentations;
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
    public class DocumentationsController : ApiController
    {
        private readonly IDocumentationsService documentationsService;

        public DocumentationsController(IDocumentationsService documentationsService)
        {
            this.documentationsService = documentationsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllDocumentationsByUserIdViewModel>>> AllByUserId()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<AllDocumentationsByUserIdViewModel> viewModel = await this.documentationsService.GetAllDocumentationsByUserIdAsync(userId);

            return this.Ok(viewModel);
        }
    }
}
