using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AsyncFileDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        [HttpGet("read-sync")]
        public string ReadSync()
        {
            Stopwatch sw = Stopwatch.StartNew();

            string basePath = Directory.GetCurrentDirectory();

            string path1 = Path.Combine(basePath, "file1.txt");
            string path2 = Path.Combine(basePath, "file2.txt");

            string debug = "";
            debug += $"Current Directory: {basePath}\n";
            debug += $"File1 Path: {path1}\n";
            debug += $"File2 Path: {path2}\n\n";

            debug += $"File1 Exists: {System.IO.File.Exists(path1)}\n";
            debug += $"File2 Exists: {System.IO.File.Exists(path2)}\n\n";

            if (!System.IO.File.Exists(path1) || !System.IO.File.Exists(path2))
            {
                return debug + "ERROR: Files not found!";
            }

            string file1Content = System.IO.File.ReadAllText(path1);
            string file2Content = System.IO.File.ReadAllText(path2);

            sw.Stop();

            return debug +
                   $"File1 Content: {file1Content}\n" +
                   $"File2 Content: {file2Content}\n" +
                   $"Time: {sw.ElapsedMilliseconds} ms";
        }


        [HttpGet("read-async")]
        public async Task<string> ReadAsync()
        {
            Stopwatch sw = Stopwatch.StartNew();

            string basePath = Directory.GetCurrentDirectory();

            string path1 = Path.Combine(basePath, "file1.txt");
            string path2 = Path.Combine(basePath, "file2.txt");

            if (!System.IO.File.Exists(path1) || !System.IO.File.Exists(path2))
            {
                return "ERROR: Files not found!";
            }

            Task<string> file1Task = System.IO.File.ReadAllTextAsync(path1);
            Task<string> file2Task = System.IO.File.ReadAllTextAsync(path2);

            string file1Content = await file1Task;
            string file2Content = await file2Task;

            sw.Stop();

            return $"File1: {file1Content}\nFile2: {file2Content}\nTime: {sw.ElapsedMilliseconds} ms";
        }
    }
}