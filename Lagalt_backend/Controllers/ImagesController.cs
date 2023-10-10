using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Net.Mime;

namespace Lagalt_backend.Controllers {
    [Route("api/v1/images")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ImagesController : ControllerBase {

        [HttpPost]
        [Route("UploadFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFile(IFormFile file, CancellationToken cancellationtoken) {
            try {
                var result = await WriteFile(file);
                return Ok(result);
            } catch (Exception ex) {
                return BadRequest($"An error occurred while uploading the file: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string filename) {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", filename);

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contenttype)) {
                contenttype = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contenttype, Path.GetFileName(filePath));
        }

        private async Task<string> WriteFile(IFormFile file) {
            string filename;
            try {
                var extension = "." + file.FileName.Split(".")[file.FileName.Split(".").Length - 1];
                filename = DateTime.Now.Ticks.ToString() + extension;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

                if (!Directory.Exists(filePath)) {
                    Directory.CreateDirectory(filePath);
                }

                var exactPath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", filename);
                using (var stream = new FileStream(exactPath, FileMode.Create)) {
                    await file.CopyToAsync(stream);
                }

            } catch (Exception ex) {
                throw ex;
            }
            return filename;
        }


    }
}
