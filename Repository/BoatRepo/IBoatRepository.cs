using FishFarm.Models;
using FishFarm.Models.Dtos;

namespace FishFarm.Repository.BoatRepo
{
    public interface IBoatRepository
    {
        Task<IEnumerable<BoatDto>> GetBoats();
        Task<Boats> GetBoatsById(int id);
        Task<Boats> PostBoats(BoatAddEditDto boatAddEditDto);
        Task PutBoat(int id, BoatAddEditDto boatAddEditDto);
        Task DeleteBoat(int id);
    }
}
