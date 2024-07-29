using Amazon.Runtime.Internal;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Song.Api.Settings;
using Song.Shared.Constants;
using Song.Shared.Request;
using Song.Shared.Response;

namespace Song.Api.Services
{
    public class SongService : ISongService
    {
        private readonly IMongoCollection<Shared.Model.Song> _songsCollection;
        public SongService(IOptions<SongDatabaseSettings> songDatabaseSettings)
        {
            var mongoClient = new MongoClient(
           songDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                songDatabaseSettings.Value.DatabaseName);

            _songsCollection = mongoDatabase.GetCollection<Shared.Model.Song>(
                songDatabaseSettings.Value.SongCollectionName);
        }

        public async Task<Response<List<Shared.Model.Song>>> GetAsync()
        {
            var songs = await _songsCollection.Find(_ => true).ToListAsync();

            return songs.Any() 
                ? new Response<List<Shared.Model.Song>>(songs)
                : new Response<List<Shared.Model.Song>>(null, code:StatusCodes.Status204NoContent);
        }
        public async Task<Response<Shared.Model.Song>> AddAsync(SongRequest request)
        {
            if (AlreadyExistSong(request))
                return new Response<Shared.Model.Song>(
                    null,
                    ErrorMessages.AlreadyExistSong,
                    StatusCodes.Status409Conflict);

            var song = new Shared.Model.Song() { Artist = request.Artist, Name = request.Name };

            await _songsCollection.InsertOneAsync(song);

            return new Response<Shared.Model.Song>(
                song, SuccessMessages.Created, StatusCodes.Status201Created);
        }
        public async Task<Response<bool>> DeleteAsync(string id)
        {
            if (!IsObjectId(id))
                return new Response<bool>(false,
                  ErrorMessages.IncorrectFormat,
                  StatusCodes.Status409Conflict);

            var result = await _songsCollection.DeleteOneAsync(f => f.Id == id);

            return result.DeletedCount > 0
                ? new Response<bool>(true, SuccessMessages.Delete)
                : new Response<bool>(false,
                string.Format(ErrorMessages.RegisterNotFound, id),
                StatusCodes.Status404NotFound);
        }
        public async Task<Response<bool>> UpdateAsync(SongRequest request, string id)
        {
            if (!IsObjectId(id))
                return new Response<bool>(false,
                  ErrorMessages.IncorrectFormat,
                  StatusCodes.Status409Conflict);

            if (AlreadyExistSong(request))
                return new Response<bool>(
                    false,
                    ErrorMessages.AlreadyExistSong,
                    StatusCodes.Status409Conflict);


            var song = new Shared.Model.Song { Artist = request.Artist, Name = request.Name };

            var result = await _songsCollection.ReplaceOneAsync(f => f.Id == id, song);

            return result.ModifiedCount > 0
                ? new Response<bool>(true, SuccessMessages.Update)
                : new Response<bool>(false,
                  string.Format(ErrorMessages.RegisterNotFound, id),
                  StatusCodes.Status404NotFound);
        }
        public bool IsObjectId(string id) =>
            ObjectId.TryParse(id, out var _);

        private bool AlreadyExistSong(SongRequest request) =>
                _songsCollection
                    .Find(f => f.Name == request.Name && f.Artist == request.Artist)
                    .Any();

    }
}
