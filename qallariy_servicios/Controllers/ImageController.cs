/*using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using qallariy_servicios.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace qallariy_servicios.Controllers
{
    //IGNORAR ESTE CONTROLADOR
    //IGNORAR ESTE CONTROLADOR
    //IGNORAR ESTE CONTROLADOR
    //IGNORAR ESTE CONTROLADOR
    //IGNORAR ESTE CONTROLADOR
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        public static IWebHostEnvironment _webHostEnvironment;
        public ImageController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public string Post([FromForm] FileUpload fileUpload)
        {
            try
            {
                if(fileUpload.files.Length>0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream=System.IO.File.Create(path+fileUpload.files.FileName))
                    {
                        fileUpload.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Upload Done";
                    }
                }
                else
                {
                    return "Failed";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        
        [HttpGet]
        public ActionResult Get([FromRoute] string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var filePath = path + fileName + ".png";
            if(System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);
                return File(b, "image/png");
            }
            return null;
        }
    }
}
*/