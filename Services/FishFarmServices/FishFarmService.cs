using AutoMapper;
using FishFarm.Controllers;
using FishFarm.Models;
using FishFarm.Models.Dtos;
using FishFarm.Repository.FishFarmRepo;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using System;
using Status = FishFarm.Models.Dtos.Status;

//******FishFarm Service*******//
namespace FishFarm.Services.FishFarmServices
{
    public class FishFarmService : IFishFarmService
    {
        private readonly IFishFarmRepository _IFishFarmRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;
        public FishFarmService(IFishFarmRepository fishFarmRepository, IWebHostEnvironment env, IMapper mapper)
        {
            _IFishFarmRepository = fishFarmRepository;
            _environment = env;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<FishFarms>>> GetFarms()
        {
            var result = await _IFishFarmRepository.GetFarms();
            if (result == null)
            {
                return new StatusCodeResult(404);
            }
            return new OkObjectResult(result);
        }

        
        public async Task<ActionResult<FishFarms>> GetFarmsById(int ffid)
        {
            var farm = await _IFishFarmRepository.GetFarmsById(ffid);
            //var farm = await _dbContext.FishFarms.FindAsync(ffid);
            if (farm == null)
            {
                return new StatusCodeResult(404);
            }
            return new OkObjectResult(farm);
        }

        public async Task<ActionResult<FishFarms>> PostFarm(FishFarms fishFarm)
        {
            return await _IFishFarmRepository.PostFarm(fishFarm);
        }

        public async Task<IActionResult> PutFishFarm(int id, FishFarms fishFarm)
        {
            await _IFishFarmRepository.PutFishFarm(id, fishFarm);
            return new ObjectResult(fishFarm) { StatusCode = 200 };
        }
        


        public async Task<ActionResult> DeleteFishFarm(int id)
        {
            var fishfarm = await _IFishFarmRepository.GetFarmsById(id);
            if (fishfarm == null)
            {
                //return NotFound();
                return new StatusCodeResult(404);
            }
            await _IFishFarmRepository.DeleteFishFarm(id);
            return new OkResult();

        }

        //------------------------------Image Post method----------------------//
        public async Task<ActionResult> SaveImage(FishFarmImgDto fishFarmImgDto)
        {
            try
            {
                var contentPath = this._environment.ContentRootPath;
                //var path = Path.Combine(contentPath, "Uploads");
                var path = Path.Combine(contentPath, "D:\\Fish_Farm_Frontend\\fish-farm-app\\public\\img");
            
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //check the allowed extentions
                var ext = Path.GetExtension(fishFarmImgDto.ImageFile.FileName);
                var allowedExtentions = new string[] { ".jpg", ".png", ".jpeg" };
                if (!allowedExtentions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extentions are allowed", string.Join(",", allowedExtentions));
                    //return new Tuple<int, string>(0, msg);
                    return new OkResult();
                }
                string uniqueString = Guid.NewGuid().ToString();
                // We are trying to crate a unique filename here
                var newFileName =  uniqueString + ext;
                var puclicImgPath = "img/" + newFileName;
                var fileWithPath = Path.Combine(path, newFileName);
                var stream = new FileStream(fileWithPath, FileMode.Create);
                fishFarmImgDto.ImageFile?.CopyTo(stream);
                stream.Close();
                //return new Tuple<int, string>(1, fileWithPath);
                fishFarmImgDto.FarmPictureUrl = puclicImgPath;
                (int, string) t = (1, fileWithPath);
                var fishfarmImgAddTo = _mapper.Map<FishFarms>(fishFarmImgDto);
                var fishfarmResult = _IFishFarmRepository.Add(fishfarmImgAddTo);
                var status = new Status();
                if (fishfarmResult)
                {
                    status.StatusCode = 1;
                    status.Messsage = "Added Successfully";
                }
                else
                {
                    status.StatusCode = 0;
                    status.Messsage = "Error on adding img";
                }

                
                return new OkResult();
            }
            catch (Exception ex)
            {
                //return new Tuple<int, string>(0, "Error has Occured" + ex.Message);
                return new OkResult();
            }
        }
    }
}
