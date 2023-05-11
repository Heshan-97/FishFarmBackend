using FishFarm.Models;
using FishFarm.Models.Dtos;
using FishFarm.Repository.BoatRepo;
using Microsoft.AspNetCore.Mvc;

namespace FishFarm.Services.BoatServices
{
    public class BoatService : IBoatService
    {
        private readonly IBoatRepository _IBoatRepository;
        public BoatService(IBoatRepository boatRepository)
        {
            _IBoatRepository  = boatRepository;
        }
        public async Task<ActionResult<IEnumerable<BoatDto>>> GetBoats()
        {
            var result = await _IBoatRepository.GetBoats();
            if (result == null)
            {
                return new StatusCodeResult(404);
            }
            return new OkObjectResult(result);
        }

        public async Task<ActionResult<Boats>> GetBoatsById(int id)
        {
            var boat = await _IBoatRepository.GetBoatsById(id);
            if (boat == null)
            {
                return new StatusCodeResult(404);
            }
            return new OkObjectResult(boat);
        }

        public async Task<ActionResult<Boats>> PostBoats(BoatAddEditDto boatAddEditDto)
        {
            return await _IBoatRepository.PostBoats(boatAddEditDto);
        }

        public async Task<IActionResult> PutBoat(int id, BoatAddEditDto boatAddEditDto)
        {
            await _IBoatRepository.PutBoat(id, boatAddEditDto);
            return new ObjectResult(boatAddEditDto) { StatusCode = 200 };
        }
        public async Task<ActionResult> DeleteBoat(int id)
        {
            var boatts = await _IBoatRepository.GetBoatsById(id);
            if (boatts == null)
            {
                //return NotFound();
                return new StatusCodeResult(404);
            }
            await _IBoatRepository.DeleteBoat(id);
            return new OkResult();
        }
    }
}
