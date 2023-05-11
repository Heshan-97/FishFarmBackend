using FishFarm.Models;
using FishFarm.Models.Dtos;
using FishFarm.Services.BoatServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FishFarm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoatController : ControllerBase
    {
        private readonly IBoatService _boatService;
        public BoatController(IBoatService boatService)
        {
            _boatService = boatService;
        }
        //GETAllDetails- Read method to arrayList 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoatDto>>> GetBoats()
        {
            return await _boatService.GetBoats();
        }

        //GET by id - Read method
        [HttpGet("{id}")]
        public async Task<ActionResult<Boats>> GetBoatsById(int id)
        {
            return await _boatService.GetBoatsById(id);
        }
        //Post-Create method
        [HttpPost]
        public async Task<ActionResult<Boats>> PostBoats(BoatAddEditDto boatAddEditDto)
        {
            return await _boatService.PostBoats(boatAddEditDto);
        }
        //Put- Updated method
        [HttpPut]
        public async Task<IActionResult> PutBoat(int id, BoatAddEditDto boatAddEditDto)
        {
            return await _boatService.PutBoat(id, boatAddEditDto);
        }
        // DELETE method
        [HttpDelete]
        public async Task<ActionResult> DeleteBoat(int id)
        {
            return await _boatService.DeleteBoat(id);
        }
    }
}
