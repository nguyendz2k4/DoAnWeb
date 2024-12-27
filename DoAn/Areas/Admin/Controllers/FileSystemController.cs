using Microsoft.AspNetCore.Mvc;
using elFinder.NetCore.Drivers.FileSystem;
using elFinder.NetCore;
using Microsoft.AspNetCore.Http.Extensions;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/el-finder-file-system")]
    public class FileSystemController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<FileSystemController> _logger;

        public FileSystemController(IWebHostEnvironment env, ILogger<FileSystemController> logger)
        {
            _env = env;
            _logger = logger;
        }

        [Route("connector")]
        public async Task<IActionResult> Connector()
        {
            try
            {
                var connector = GetConnector();
                var result = await connector.ProcessAsync(Request);
                if (result is JsonResult json)
                {
                    return Content(JsonSerializer.Serialize(json.Value), json.ContentType);
                }
                else
                {
                    return Json(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Connector method");
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("thumb/{hash}")]
        public async Task<IActionResult> Thumbs(string hash)
        {
            try
            {
                var connector = GetConnector();
                return await connector.GetThumbnailAsync(HttpContext.Request, HttpContext.Response, hash);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Thumbs method");
                return StatusCode(500, "Internal server error");
            }
        }

        private Connector GetConnector()
        {
            // Thư mục gốc lưu trữ là wwwwroot/files (đảm bảo có tạo thư mục này)
            string pathroot = "file";

            var driver = new FileSystemDriver();

            string absoluteUrl = UriHelper.BuildAbsolute(Request.Scheme, Request.Host);
            var uri = new Uri(absoluteUrl);

            // .. ... wwww/files
            string rootDirectory = Path.Combine(_env.WebRootPath, pathroot);

            // https://localhost:5001/files/
            string url = $"/{pathroot}/";
            string urlthumb = $"{uri.Scheme}://Admin/el-finder-file-system/thumb/";

            var root = new RootVolume(rootDirectory, url, urlthumb)
            {
                //IsReadOnly = !User.IsInRole("Administrators")
                IsReadOnly = false, // Can be readonly according to user's membership permission
                IsLocked = false, // If locked, files and directories cannot be deleted, renamed or moved
                Alias = "Files", // Beautiful name given to the root/home folder
                //MaxUploadSizeInKb = 2048, // Limit imposed to user uploaded file <= 2048 KB
                //LockedFolders = new List<string>(new string[] { "Folder1" }
                ThumbnailSize = 100,
            };

            driver.AddRoot(root);

            return new Connector(driver)
            {
                // This allows support for the "onlyMimes" option on the client.
                MimeDetect = MimeDetectOption.Internal
            };
        }
    }
}
