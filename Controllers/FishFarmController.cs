using FishFarm.Models;
using FishFarm.Models.Dtos;
using FishFarm.Models.FileUp;
using FishFarm.Repository.FishFarmRepo;
using FishFarm.Services.FishFarmServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FishFarm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishFarmController : ControllerBase
    {
        private readonly IFishFarmService _fishFarmService; //IFishFarmService interface dependancy injection
        private readonly IFishFarmRepository _fishFarmRepository;

        public FishFarmController(IFishFarmService fishFarmService, IFishFarmRepository fishFarmRepository)
        { 
            _fishFarmService = fishFarmService;
            _fishFarmRepository= fishFarmRepository;
        }

        //GETAllDetails- Read method to arrayList 
        [HttpGet(Name ="List of Farms")]
        public async Task<ActionResult<IEnumerable<FishFarms>>> GetFarms()
        {
            return await _fishFarmService.GetFarms();
        }

        //GET by id - Read method
        [HttpGet("{id}")]
        public async Task<ActionResult<FishFarms>> GetFarmsById(int id)
        {
            return await _fishFarmService.GetFarmsById(id);
        }
        //Post-Create method
        [HttpPost]
        public async Task<ActionResult<FishFarms>> PostFarm(FishFarms fishFarm)
        {
            return await _fishFarmService.PostFarm(fishFarm);
        }
        //Put- Updated method
        [HttpPut]
        public async Task<IActionResult> PutFishFarm(int id, FishFarms fishFarm)
        {
            return await _fishFarmService.PutFishFarm(id, fishFarm);
        }
        
        // DELETE method
        [HttpDelete]
        public async Task<ActionResult> DeleteFishFarm(int id)
        {
            return await _fishFarmService.DeleteFishFarm(id);
        }
        //------------------------------Image Post method----------------------//

        [HttpPost("SaveImage")]
        public IActionResult Add([FromForm]FishFarmImgDto fishFarmImgDto) 
        {
            var status = new Status();
            if(!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Messsage = "Please pass the valid data";
                return Ok(status);
            }
            if(fishFarmImgDto.ImageFile != null)
            {
                //fishFarmImgDto.FarmPictureUrl = fishFarmImgDto.ImageFile.FileName; //getting name of image
                var fileResult = _fishFarmService.SaveImage(fishFarmImgDto);
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
