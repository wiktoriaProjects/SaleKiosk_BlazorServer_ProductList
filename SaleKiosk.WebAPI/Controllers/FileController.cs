using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace SaleKiosk.SharedKernel.Controllers
{
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        [HttpGet]
        public ActionResult DownloadFile([FromQuery] string fileName)
        {
            // create file path
            var dir = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(dir, "Files", fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            // MIME type
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out string mimeType))
            {
                mimeType = "application/octet-stream";
            }

            // read file content
            var bytes = System.IO.File.ReadAllBytes(filePath);

            //return file
            return File(bytes, mimeType, fileName);
        }

        [HttpPost]
        public ActionResult UploadFile(IFormFile file)
        {
            // walidation
            if (file == null)
            {
                return BadRequest();
            }

            // create file path
            var dir = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(dir, "Files", file.FileName);

            // upload file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Ok();
        }
    }
}
