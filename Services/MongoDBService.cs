using MongoDB.Bson;
using MongoDB.Driver;
using Mongo.POC.Models;
using Microsoft.Extensions.Options;

namespace Mongo.POC.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Playlist> _playlistCollection;

    public MongoDBService(IOptions<MongoDBSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _playlistCollection = database.GetCollection<Playlist>(settings.Value.CollectionName);
    }
    
    public async Task CreateAsync(Playlist playlist)
    {
        await _playlistCollection.InsertOneAsync(playlist);
    }

    public async Task<List<Playlist>> GetPlaylistAsync()
    {
        return await _playlistCollection.Find(new BsonDocument()).ToListAsync();
    }
    
    public async Task<Playlist> GetPlaylistByIdAsync(string id)
    {
        return await _playlistCollection.Find(x => x.Id == id).FirstAsync();
    }
    
    public async Task AddToPlaylistAsync(string id, string movieId)
    {
        var filter = Builders<Playlist>.Filter.Eq("Id", id);
        var update = Builders<Playlist>.Update.AddToSet("items", movieId);
        await _playlistCollection.UpdateOneAsync(filter, update);
    }
    
    public async Task DeletePlaylistAsync(string id)
    {
        var filter = Builders<Playlist>.Filter.Eq("Id", id);
        await _playlistCollection.DeleteOneAsync(filter);
    }
}