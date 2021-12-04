using AliceDriveData.Interfaces;
using AliceDriveEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliceDriveApi.Controllers
{
    [Route("api/archives")]
    [ApiController]
    public class ArchivesController : Controller
    {
        private readonly IFilesConsummer filesConsummer;
        private AppSettings settings;
        public ArchivesController(IFilesConsummer filesConsummer, IOptions<AppSettings> options)
        {
            this.filesConsummer = filesConsummer;
            this.settings = options.Value;
        }

        [Route("")]
        [HttpGet]
        public async Task<ActionResult> getRoot()
        {
            try
            {
                return Json(await filesConsummer.getDisk(settings, 1));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult> createDisk([FromBody] Files file)
        {
            try
            {
                await filesConsummer.createDisk(settings, file, 1);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Route("{baseId}")]
        [HttpPost]
        public async Task<ActionResult> createArchive([FromBody] Files file, string baseId)
        {
            try
            {
                file.FileBase = baseId;
                file.FileSize = 0;
                file.FileType = "folder";
                await filesConsummer.upload(settings, file, null, 1);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
