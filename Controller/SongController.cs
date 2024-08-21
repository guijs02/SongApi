using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Request;
using Song.Api.Services;

namespace Song.Api.Controller
{
    [ApiController]
    [Route("/v1/[controller]")]
    public class SongController(ISongService songService) : ControllerBase
    {
        private readonly ISongService _songService = songService;

        [HttpGet]
        public async Task<IActionResult> GetSongs()
        {
            var songs = await _songService.GetAsync();
            
            return Ok(songs);
        }
        [HttpPost]
        public async Task<IActionResult> AddSong(SongRequest request)
        {
            var response = await _songService.AddAsync(request);

            return StatusCode(response.StatusCode, response);
        }  
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(string id)
        {
            var response = await _songService.DeleteAsync(id);

            return StatusCode(response.StatusCode, response);
        }    
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSong([FromBody] SongRequest request, string id)
        {
            var response = await _songService.UpdateAsync(request,id);

            return StatusCode(response.StatusCode, response);
        }
    }
}
