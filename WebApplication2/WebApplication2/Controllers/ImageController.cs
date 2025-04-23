using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace WebApplication2.Controllers
{
    public class ImageController : Controller
    {
        [HttpGet]
        public IActionResult Resize()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ToGray()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResizeAsync(IFormFile imageFile, int width, int height)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                ViewBag.Error = "請上傳圖片";
                return View();
            }

            byte[] originalBytes;

            using (var inputStream = imageFile.OpenReadStream())
            using (var image = await Image.LoadAsync(inputStream))
            {
                // 原圖存起來
                using var originalStream = new MemoryStream();
                await image.SaveAsJpegAsync(originalStream);
                originalBytes = originalStream.ToArray();

                // Resize 圖片
                image.Mutate(x => x.Resize(width, height));
                using var resizedStream = new MemoryStream();
                await image.SaveAsJpegAsync(resizedStream);
                ViewBag.ResizedImage = Convert.ToBase64String(resizedStream.ToArray());
            }

            ViewBag.OriginalImage = Convert.ToBase64String(originalBytes);
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ToGray(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                ViewBag.Error = "請上傳圖片";
                return View();
            }

            byte[] originalBytes;

            using (var inputStream = imageFile.OpenReadStream())
            using (var originalImage = await Image.LoadAsync(inputStream))
            {
                // 儲存原始圖
                using var originalStream = new MemoryStream();
                await originalImage.SaveAsJpegAsync(originalStream);
                originalBytes = originalStream.ToArray();

                // 再轉換灰階
                originalImage.Mutate(x => x.Grayscale());
                using var grayStream = new MemoryStream();
                await originalImage.SaveAsJpegAsync(grayStream);
                ViewBag.ImageBytes = Convert.ToBase64String(grayStream.ToArray());
            }

            ViewBag.OriginalImage = Convert.ToBase64String(originalBytes);
            return View();
        }


    }
}
