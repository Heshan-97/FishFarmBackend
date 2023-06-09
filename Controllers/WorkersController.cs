﻿using Azure;
using FishFarm.Models;
using FishFarm.Models.Dtos;
using FishFarm.Models.FileUp;
using FishFarm.Services.FishFarmServices;
using FishFarm.Services.WorkerServices;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Response = FishFarm.Models.FileUp.Response;

namespace FishFarm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService _workderService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public WorkersController(IWorkerService workerService, IWebHostEnvironment webHostEnvironment)
        {
           _workderService = workerService; // for IServices
           _webHostEnvironment = webHostEnvironment;   // for file upload[Image] 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkersDto>>> GetWorkers()
        {
            return await _workderService.GetWorkersDto();
        }

        //GET by id - Read method
        [HttpGet("{id}")]
        public async Task<ActionResult<Workers>> GetWorkerById(int id)
        {
            return await _workderService.GetWorkerById(id);
        }
        //Post-Create method
        [HttpPost]
        public async Task<ActionResult<Workers>> PostWorker(Workers workers)
        {
            return await _workderService.PostWorker(workers);
        }
        //Put- Updated method
        [HttpPut]
        public async Task<IActionResult> PutWorkers(int id, Workers workers)
        {
            return await _workderService.PutWorkers(id, workers);
        }
        // DELETE method
        [HttpDelete]
        public async Task<ActionResult> DeleteWorker(int id)
        {
            return await _workderService.DeleteWorker(id);
        }
        //-----------------------------------Dto  getmethof------------------------------------
        [HttpGet("dto")]
        public async Task<ActionResult<IEnumerable<WorkersDto>>> GetWorkersDto()
        {
            var workers = await _workderService.GetWorkersDto();
            if (workers == null)
            {
                return NotFound();
            }
            return Ok(workers);
        }
        [HttpPost("dto")]
        public async Task<ActionResult<Workers>> PostWorker(WorkerDtoEdit workersDtoEdit)
        {
            return await _workderService.PostWorkerDto(workersDtoEdit);
        }
        [HttpPut("dto")]
        public async Task<IActionResult> PutWorkersDto(int idd, WorkerDtoEdit workersDtoEdit)
        {
            return await _workderService.PutWorkersDto(idd, workersDtoEdit);
        }
        //<--------------------------------------File Upload[Image]---------------------------------------------->
        /*[HttpPost("PostUpload")]
        public async Task<string> PostUpload([FromForm] FileUpload fileUpload)
        {
            try
            {
                if(fileUpload.files.Length > 0 )
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if(!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + fileUpload.files.FileName)) 
                    {
                        fileUpload.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Upload Done.";
                    }
                }
                else 
                {
                    return "Failed.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
                
            }
        }
        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetFileUpload([FromRoute] string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\upload";
            var filePath = path + fileName + ".png"; 
            if(System.IO.File.Exists(filePath)) 
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);
                return File(b, "image/png");
            }
            return null;
        }*/
        [HttpPost]
        [Route("UploadFile")]
        public Response UploadFile([FromForm] FileModel fileModel)
        {
            Response response = new Response();
            try
            {
                string path = Path.Combine(@"D:\Fish_Farm_Backend\FishFarm\Img", fileModel.FileName + ".png");
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    fileModel.File.CopyTo(stream);
                }
                response.StatusCode = 200;
                response.ErrorMessage = "Image Craeted successfully";
            }
            catch (Exception ex)
            {
                response.StatusCode=100;
                response.ErrorMessage = "Some Error Occured" + ex.Message ;
            }
            return response;
        }
        //------------------------------Image Post method----------------------//

        [HttpPost("SaveImage")]
        public IActionResult Add([FromForm] WorkersImgDto workersImgDto )
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Messsage = "Please pass the valid data";
                return Ok(status);
            }
            if (workersImgDto.ImageFile != null)
            {
                //fishFarmImgDto.FarmPictureUrl = fishFarmImgDto.ImageFile.FileName; //getting name of image
                var fileResult = _workderService.SaveImage(workersImgDto);
                /*if(fileResult.Item1 == 1)
                {
                    fishFarmImgDto.FarmPictureUrl = fileResult.Item2; //getting name of image
                }
                /*var fishfarmResult = _fishFarmRepository.Add(fishFarmImgDto);
                if(fishfarmResult)
                {
                    status.StatusCode = 1;
                    status.Messsage = "Added Successfully";
                }
                else
                {
                    status.StatusCode = 0;
                    status.Messsage = "Error on adding img";
                 }*/

            }
            return Ok(status);
        }

    }
}
