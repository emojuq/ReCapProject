using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //bu işlem resim ekleme işlemidir sonra startup'a bak
    public partial class CarImagesController : ControllerBase
    {
        IWebHostEnvironment _webHostEnvironment;
        ICarImageService _carImageService;

        public CarImagesController(IWebHostEnvironment webHostEnvironment, ICarImageService carImageService)
        {
            _webHostEnvironment = webHostEnvironment;
            _carImageService = carImageService;
        }

        public class FileUpload
        {
            public IFormFile files { get; set; }

            public IFormFile carid { get; set; }
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetPhotosByCarId([FromForm(Name =("CarId"))]int id)
        {
            var result = _carImageService.GetPhotosByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(file.FileName);
            string fileEx = fileInfo.Extension;

            var path = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }


            var carimage = new CarImage { CarId = carImage.CarId, ImagePath = path, Date = DateTime.Now };

            var result = _carImageService.Add(carimage, fileEx);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add2")]
        public IActionResult Add2(CarImage carImage)
        {
            var result = _carImageService.Add(carImage, ".png");
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("add3")]
        public async Task<string> Add3([FromForm] FileUpload file, [FromForm] CarImage carImage)
        {


            System.IO.FileInfo ff = new System.IO.FileInfo(file.files.FileName);
            string fileExtension = ff.Extension;


            var createdUniqueFilename = Guid.NewGuid().ToString("N")
                + "_" + DateTime.Now.Month + "_"
                + DateTime.Now.Day + "_"
                + DateTime.Now.Year + fileExtension;


            string path = "";
            if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\uploads\\"))
            {
                Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\uploads\\");
            }


            using (FileStream fs = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\uploads\\" + createdUniqueFilename))
            {
                await file.files.CopyToAsync(fs);

                path = _webHostEnvironment.WebRootPath + "\\uploads\\" + createdUniqueFilename;

                fs.Flush();
            }


            await AddAsync(file.files, carImage);

            return "\\uploads\\" + createdUniqueFilename;


        }



        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost("update")]
        public IActionResult Update(CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
    
}




    



