using Microsoft.AspNetCore.Mvc;
using SupplyChainManagement.Models;

namespace SupplyChainManagement.Controllers
{
    public class POTrackerController : Controller
    {
        private readonly string _fileDirectory = @"D:\File";
        public IActionResult Index()
        {
            var model = GetFiles();
            return View(model);
        }

        private List<FileModelcs> GetFiles()
        {
            var files = new List<FileModelcs>();

            if (Directory.Exists(_fileDirectory))
            {
                var fileInfos = Directory.GetFiles(_fileDirectory);
                foreach (var filePath in fileInfos)
                {
                    var fileInfo = new FileInfo(filePath);
                    files.Add(new FileModelcs
                    {
                        FileName = fileInfo.Name,
                        FilePath = fileInfo.FullName,
                        FileSize = fileInfo.Length
                    });
                }
            }
            return files;
        }

        [HttpGet]
        public IActionResult DownloadFile(string fileName)
        {
            var filePath = Path.Combine(_fileDirectory, fileName);

            if (System.IO.File.Exists(filePath))
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/octet-stream", fileName);
            }
            return NotFound(); 
        }

    }
}
