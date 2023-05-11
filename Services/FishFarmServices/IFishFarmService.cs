using FishFarm.Controllers;
using FishFarm.Models;
using FishFarm.Models.Dtos;
//******FishFarm Repository Interface*******//
using Microsoft.AspNetCore.Mvc;

namespace FishFarm.Services.FishFarmServices
{
    public interface IFishFarmService 
    {
        Task<ActionResult<IEnumerable<FishFarms>>> GetFarms();
        Task<ActionResult<FishFarms>> GetFarmsById(int id);
        Task<ActionResult<FishFarms>> PostFarm(FishFarms fishFarm);
        Task<IActionResult> PutFishFarm(int id, FishFarms fishFarm);
        Task<ActionResult> DeleteFishFarm(int id);
        Task<ActionResult> SaveImage(FishFarmImgDto fishFarmImgDto);
    }
}
