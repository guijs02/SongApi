using Song.Shared.Request;
using Song.Shared.Response;

namespace Song.Api.Services
{
    public interface ISongService
    {
        Task<Response<List<Shared.Model.Song>>> GetAsync();
        Task<Response<Shared.Model.Song>> AddAsync(SongRequest request);
        Task<Response<bool>> DeleteAsync(string id);
        Task<Response<bool>> UpdateAsync(SongRequest req, string id);
    }
}
