using Instahach.Models;

namespace Instahach.Services;

public interface IImageService
{
    public IEnumerable<ImageResponse> GetImages(int skip, int take);
    public bool LikeImage(LikeRequest likeRequest);

    public bool PostImage(string path, Guid userId);

}