using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Tags;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Controllers
{
    public class TagsController : ApiController
    {
        private readonly ITagsService tagsService;

        public TagsController(ITagsService tagsService)
        {
            this.tagsService = tagsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllTagsForDropDownViewModel>>> GetAll()
        {
            IEnumerable<AllTagsForDropDownViewModel> viewModel = await this.tagsService.GetAllForDropDown();
            return this.Ok(viewModel);
        }
    }
}
