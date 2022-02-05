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
    [Route("api/posts")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostConsummer postConsummer;
        private AppSettings settings;
        public PostController(IPostConsummer postConsummer, IOptions<AppSettings> options)
        {
            this.postConsummer = postConsummer;
            this.settings = options.Value;
        }


        [Route("{idUsuario}")]
        [HttpGet]
        public async Task<ActionResult<List<Post>>> get(int idUsuario)
        {
            try
            {
                return await postConsummer.getByUsuario(settings, idUsuario);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult> create([FromBody] Post post)
        {
            try
            {
                await postConsummer.create(settings, post);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
