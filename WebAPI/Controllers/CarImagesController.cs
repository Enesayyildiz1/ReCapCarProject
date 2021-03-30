using BusinessLogic.Abstract;
using Core.Utilities.FileHelper;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImagesService;
        IWebHostEnvironment _webHostEnvironment;

        public CarImagesController(ICarImageService carImagesService, IWebHostEnvironment webHostEnvironment)
        {
            _carImagesService = carImagesService;
            _webHostEnvironment = webHostEnvironment;


        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImagesService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int carId)
        {//C:\Users\Enes\source\repos\ReCapCarProjectt\WebAPI\wwwroot\uploads\002c73e6-aa22-4386-8748-c9913a650685_99_15_17.jfif

            var result = _carImagesService.GetByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
           
            if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\uploads\\"))
            {
                Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\uploads\\");
            }
            using (FileStream fs = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\uploads\\" + file.FileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }


            var result = _carImagesService.Add(file, carImage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm(Name =("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int id )
        {
            var carImage = _carImagesService.GetById(id).Data;
            var result = _carImagesService.Update(file, carImage);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int Id)
        {

            var carImage = _carImagesService.GetById(Id).Data;

            var result = _carImagesService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



    }
}
