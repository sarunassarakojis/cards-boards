using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GossipBoard.Models;
using GossipBoard.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GossipBoard.Controllers
{
    [Route("api/fileUpload")]
    public class FileUploadController : Controller
    {
        private readonly IFileSaveService _fileService;

        public FileUploadController(IFileSaveService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        [Produces(typeof(FileUploadResultDto))]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            if (files.Count == 0)
            {
                return BadRequest("Missing file. Are you missing form-data file key?");
            }

            var result = await _fileService.Save(files.FirstOrDefault());

            return Ok(result);
        }
    }
}
