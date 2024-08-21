using Shared.Model;
using Shared.Request;
using Shared.Response;

namespace Song.Api.Services
{
    public interface ISongService
    {
        Task<Response<List<Songs>>> GetAsync();
        Task<Response<Songs>> AddAsync(SongRequest request);
        Task<Response<bool>> DeleteAsync(string id);
        Task<Response<bool>> UpdateAsync(SongRequest req, string id);
    }
}
