using CandidateMGMT.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CandidateMGMT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public FileUploadController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public async Task Post(UploadedFile file)
        {
            var path = $"{_env.WebRootPath}\\{file.FileName}";
            var fs = System.IO.File.Create(path);
            await fs.WriteAsync(file.FileContent,0, file.FileContent.Length);
            fs.Close();
        }
    }
}
