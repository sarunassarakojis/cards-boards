using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GossipBoard.Models;
using Microsoft.AspNetCore.Http;

namespace GossipBoard.Services
{
    public interface IFileSaveService
    {
         Task<FileUploadResultDto> Save(IFormFile file);
    }
}
