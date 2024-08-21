using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Shared.Request;

namespace Shared.Model
{
    public class Songs
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Artist { get; set; } = null!;

        public static implicit operator Songs(SongRequest song) => 
            new() { Artist = song.Artist, Name = song.Name };

    }
}