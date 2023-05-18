using Instahach.Models;

namespace Instahach.Services;

public class MockImageService: IImageService
{
    public IEnumerable<ImageResponse> GetImages(int skip, int take)
    {
        return new[]
        {
            new ImageResponse
            {
                Id = Guid.NewGuid(),
                NumberOfLikes = 10,
                Path = "/images/img1.png"
            },
            new ImageResponse
            {
                Id = Guid.NewGuid(),
                NumberOfLikes = 2,
                Path = "/images/img1.png"
            },
            new ImageResponse
            {
                Id = Guid.NewGuid(),
                NumberOfLikes = 1,
                Path = "/images/img1.png"
            }
        };
    }

    public bool LikeImage(LikeRequest likeRequest)
    {
        return true;
    }

    public bool PostImage(string path, Guid userId)
    {
        return true;
    }
}