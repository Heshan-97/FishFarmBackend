using AutoMapper;
using FishFarm.Models;
using FishFarm.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FishFarm.Repository.BoatRepo
{
    public class BoatRepository : IBoatRepository
    {
        private readonly FishFarmDBContext _dbContext;
        private readonly IMapper _mapper;
        public BoatRepository(FishFarmDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BoatDto>> GetBoats()
        {
            var boatDto = await _dbContext.Boats.Include(w => w.FishFarms).ToListAsync();
            return boatDto.Select(w => _mapper.Map<BoatDto>(w));
        }

        public async Task<Boats> GetBoatsById(int id)
        {
            return await _dbContext.Boats.FirstOrDefaultAsync(boat => boat.BoatId == id);
        }

        public async Task<Boats> PostBoats(BoatAddEditDto boatAddEditDto)
        {
            var boatAddto = _mapper.Map<Boats>(boatAddEditDto);
            _dbContext.Boats.Add(boatAddto);
            await _dbContext.SaveChangesAsync();
            return boatAddto;
        }

        public async Task PutBoat(int id, BoatAddEditDto boatAddEditDto)
        {
            var existingBoat = await _dbContext.Boats.FindAsync(id);
            if (existingBoat == null)
            {
                throw new InvalidOperationException("Cannot update a farm that does not exist.");
            }

            existingBoat.BoatName = boatAddEditDto.BoatName;
            existingBoat.GpsPosition = boatAddEditDto.GpsPosition;
            existingBoat.NoOfCages = boatAddEditDto.NoOfCages;
            existingBoat.FishFarmsFarmId= boatAddEditDto.FishFarmsFarmId;

            _dbContext.Entry(existingBoat).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteBoat(int id)
        {
            var boats = await _dbContext.Boats.FindAsync(id);
            if (boats != null)
            {
                _dbContext.Boats.Remove(boats);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
