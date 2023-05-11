using FishFarm.Models;
using FishFarm.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

//***************Fish FaRepository Interface************/
namespace FishFarm.Repository.FishFarmRepo
{
    public interface IFishFarmRepository
    {
        Task<IEnumerable<FishFarms>> GetFarms();
        Task<FishFarms> GetFarmsById(int id);
        Task<FishFarms> PostFarm(FishFarms fishFarm);
        Task PutFishFarm(int id, FishFarms fishFarm);
        Task DeleteFishFarm(int id);
        bool Add(FishFarms fishFarms);
     
    }
}
