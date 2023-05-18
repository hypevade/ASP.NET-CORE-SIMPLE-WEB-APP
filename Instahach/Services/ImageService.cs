using Instahach.Domain;
using Instahach.Domain.Entities;
using Instahach.Models;

namespace Instahach.Services;

class ImageService : IImageService
{
    private readonly ApplicationDbContext _dbContext;

    public ImageService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<ImageResponse> GetImages(int skip, int take)
    {
        var images = _dbContext.Images.Skip(skip).Take(take).Select(img => new ImageResponse
        {
            Id = img.Id, Path =  img.Path, NumberOfLikes = _dbContext.Likes.Count(like => like.Image == img)
        }).ToArray();
        return images;
    }

    public bool LikeImage(LikeRequest likeRequest)
    {
        _dbContext.Likes.Add(new Like()
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            Image = _dbContext.Images.First(img => img.Id == likeRequest.ImageId),
            Sender = _dbContext.Users.First(user => user.Id == likeRequest.UserId),
        });
        _dbContext.SaveChanges();
        return true;
    }
    
    public bool PostImage(string path, Guid userId)
    {
        _dbContext.Images.Add(new Image()
        {
            Id = Guid.NewGuid(),
            IsActive = true,
            Path = path,
            Sender = new User(){Id = Guid.NewGuid(),CreatedAt = DateTime.UtcNow, Email = "ffsdadfs@mail.ru", IsActive = true,Name = "hypevade"}/*_dbContext.Users.First(user => user.Id == userId)*/
        });
        _dbContext.SaveChanges();
        return true;
    }
}