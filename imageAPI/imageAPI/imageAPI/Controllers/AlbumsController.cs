using BAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSUS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private IAlbumService _albumService;
        public AlbumsController(IAlbumService albumService) 
        {
            _albumService = albumService;
        }

        [HttpGet("GetAlbums")]
        public IActionResult GetAlbums() { 
            var result = _albumService.GetAlbumsList();
            return Ok(result);
        }

        [HttpGet("GetAlbumsImages")]
        public IActionResult GetAlbumsImages(int albumID)
        {
            var result = _albumService.GetAlbumsImagesList(albumID);
            return Ok(result);
        }
    }
}
