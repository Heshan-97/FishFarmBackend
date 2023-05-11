using FishFarm.Models;
using FishFarm.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FishFarm.Services.BoatServices
{
    public interface IBoatService
    {
        Task<ActionResult<IEnumerable<BoatDto>>> GetBoats();
        Task<ActionResult<Boats>> GetBoatsById(int id);
        Task<ActionResult<Boats>> PostBoats(BoatAddEditDto boatAddEditDto);
        Task<IActionResult> PutBoat(int id, BoatAddEditDto boatAddEditDto);
        Task<ActionResult> DeleteBoat(int id);
    }
}
