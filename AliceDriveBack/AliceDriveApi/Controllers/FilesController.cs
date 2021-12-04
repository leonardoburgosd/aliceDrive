using AliceDriveData.Interfaces;
using AliceDriveEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace AliceDriveApi.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : Controller
    {
        private readonly IFilesConsummer filesConsummer;
        private AppSettings settings;
        public FilesController(IFilesConsummer filesConsummer, IOptions<AppSettings> options)
        {
            this.filesConsummer = filesConsummer;
            this.settings = options.Value;
        }

        [Route("")]
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 4294967295)]
        [RequestSizeLimit(4294967295)]
        public async Task<ActionResult> Upload()
        {
            try
            {
                IFormFile fileGet = Request.Form.Files[0];

                IFormCollection formCollection = Request.ReadFormAsync().Result;

                Files file = new Files()
                {
                    FileBase = formCollection["fileBase"].ToString(),
                    FileNombre = formCollection["FileNombre"].ToString(),
                    FileSize = Convert.ToInt32(formCollection["FileSize"]),
                    FileType = formCollection["FileType"].ToString(),
                    FileUsuarioRegistro = 1
                };

                await filesConsummer.upload(settings, file, fileGet, 1);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Route("{baseId}")]
        [HttpGet]
        public async Task<ActionResult> GetChildren(string baseId)
        {
            try
            {
                return Json(await filesConsummer.getChildren(settings,baseId,1));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Route("download/{baseId}")]
        [HttpGet]
        public async Task<ActionResult> download(string baseId) {
            try
            {
                (string, string, string) response = await filesConsummer.download(settings, baseId, 1);
                string file = response.Item1;
                string type = response.Item2;
                string name = response.Item3;
                return Json(new { file, type, name });
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        //PRUEBA
        [Route("flie")]
        [HttpGet]
        public FileResult getFileById()
        {
            return PhysicalFile($"F:\\Videos\\Anime\\Strike the Blood\\1.mp4", "application/octet-stream", enableRangeProcessing: true);
        }
    }
}
