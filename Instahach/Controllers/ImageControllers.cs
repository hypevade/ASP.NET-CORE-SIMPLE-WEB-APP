using Instahach.Services;
using Microsoft.AspNetCore.Mvc;

namespace Instahach.Controllers;

[Route("images")]
public class ImageControllers: Controller
{
    private readonly IImageService _imageService;
    private readonly IWebHostEnvironment  _webHostEnvironment;

    public ImageControllers(IImageService imageService, IWebHostEnvironment webHostEnvironment)
    {
        _imageService = imageService;
        _webHostEnvironment = webHostEnvironment;
    }
    [Route("")]
    
    public ViewResult GetImages()
    {
        ViewBag.Title = "Все фото";
        var skip = 0;
        var take = 10;
        var images = _imageService.GetImages(skip, take);
        return View(images);
    }
    
    [HttpGet]
    [Route("post")]
    public IActionResult Upload()
    {
        return View();
    }
    
    [HttpPost]
    [Route("post")]
    public IActionResult UploadPost()
    {
        var imageFile = Request.Form.Files["imageFile"];

        if (imageFile != null && imageFile.Length > 0)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            string uniqueFileName = Guid.NewGuid() + "_" + imageFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            _imageService.PostImage($"images\\{uniqueFileName}", Guid.NewGuid());

            // Сохраняем файл на сервере
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }

            // Можно выполнить дополнительные действия, например, сохранить путь к файлу в базе данных

            return RedirectToAction("GetImages"); // Редирект на другую страницу после загрузки файла
        }

        // Если файл не был загружен, можно вернуть сообщение об ошибке или выполнить другую обработку
        return RedirectToAction("Error");
    }
    
    [Route("error")]
    public IActionResult Error()
    {
        return View();
    }
}