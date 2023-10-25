using Mongo.POC.Models;
using Mongo.POC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mongo.POC.Controllers;

[Controller]
[Route("api/[controller]")]
public class PlaylistController : Controller
{
    private readonly MongoDBService _mongoDbService;
    
    public PlaylistController(MongoDBService mongoDbService)
    {
        _mongoDbService = mongoDbService;
    }
    
    [HttpGet]
    public async Task<List<Playlist>> Get()
    {
        return await _mongoDbService.GetPlaylistAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<Playlist> Get(string id)
    {
        return await _mongoDbService.GetPlaylistByIdAsync(id);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Playlist playlist)
    {
        await _mongoDbService.CreateAsync(playlist);
        var actionResult = CreatedAtAction(nameof(Get), new { id = playlist.Id }, playlist);
        return actionResult;
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string movieId)
    {
        await _mongoDbService.AddToPlaylistAsync(id, movieId);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _mongoDbService.DeletePlaylistAsync(id);
        return NoContent();
    }
    
}