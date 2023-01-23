using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageAPI_Manjula.Services;

namespace StorageAPI_Manjula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileSharestorageController : ControllerBase
    {
            private readonly IFileShareStorage _fileshareService;
            public FileSharestorageController(IFileShareStorage fileshareService)
            {
                _fileshareService = fileshareService ?? throw new ArgumentNullException(nameof(fileshareService));
            }

            [HttpGet]
            [Route("GetAllFiles")]
            public async Task<List<string>> GetAllFiles()
            {
                return await _fileshareService.GetAllFileShares();
            }

            [HttpPost]
            [Route("Create")]
            public async Task<bool> Create(string dirName, string fileShare, IFormFile inputfile)
            {

                await _fileshareService.FileShareAsync(dirName, inputfile.FileName, fileShare, inputfile.OpenReadStream());                    
                return true;
            }

            [HttpDelete]
            [Route("Delete")]
            public async Task<bool> Delete(string shareName)
            {
                await _fileshareService.DeleteSnapshotAsync(shareName);
                return true;
            }
        }
    }


