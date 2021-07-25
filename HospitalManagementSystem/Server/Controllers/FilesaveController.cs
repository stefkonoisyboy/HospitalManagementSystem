using HospitalManagementSystem.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Controllers
{
    public class FilesaveController : ApiController
    {
        private readonly IWebHostEnvironment env;
        private readonly ILogger<FilesaveController> logger;

        public FilesaveController(IWebHostEnvironment env,
            ILogger<FilesaveController> logger)
        {
            this.env = env;
            this.logger = logger;
        }

       [HttpPost]
        public async Task<string> Save()
        {
            string path = string.Empty;
            if (HttpContext.Request.Form.Files.Any())
            {
                foreach (var file in HttpContext.Request.Form.Files)
                {
                    path = Path.Combine(env.ContentRootPath, "uploads", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            byte[] ByteArray = System.IO.File.ReadAllBytes(path);

            return Convert.ToBase64String(ByteArray);
        }
    }
}
