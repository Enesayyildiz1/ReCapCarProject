﻿using BusinessLogic.Abstract;
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
        public IActionResult GetImagesByCarId([FromForm(Name = ("CarId"))] int carId)
        {
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
           
            if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\images\\"))
            {
                Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\images\\");
            }
            using (FileStream fs = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\images\\" + file.FileName))
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
