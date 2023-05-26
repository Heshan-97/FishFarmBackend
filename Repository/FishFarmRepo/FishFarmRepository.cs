using AutoMapper;
using FishFarm.Models;
using FishFarm.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

//***************Fish Farm Repository************/
namespace FishFarm.Repository.FishFarmRepo
{
    public class FishFarmRepository : IFishFarmRepository
    {
        private readonly FishFarmDBContext _dbContext;
        private readonly IMapper _mapper;
        public FishFarmRepository(FishFarmDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FishFarms>> GetFarms()
        {
            
            return await _dbContext.FishFarms.ToListAsync();
        }
        public async Task<FishFarms> GetFarmsById(int id)
        {
            
            return await _dbContext.FishFarms.FirstOrDefaultAsync(fishFarm => fishFarm.FarmId == id);
            
        }
        public async Task<FishFarms> PostFarm(FishFarms fishFarm)
        {
            var result = _dbContext.FishFarms.Add(fishFarm); //  obj of fishFarm class from react js
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task PutFishFarm(int id, FishFarms fishFarm)
        {
            var existingFarm = await _dbContext.FishFarms.FindAsync(id);
            if (existingFarm == null)
            {
                throw new InvalidOperationException("Cannot update a farm that does not exist.");
            }

            existingFarm.FarmName = fishFarm.FarmName;
            existingFarm.FarmPictureUrl = fishFarm.FarmPictureUrl;
            existingFarm.BargeAvailability = fishFarm.BargeAvailability;

            _dbContext.Entry(existingFarm).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }
        
        public async Task DeleteFishFarm(int id)
        {
            var farms = await _dbContext.FishFarms.FindAsync(id);
            if (farms != null)
            {
                _dbContext.FishFarms.Remove(farms);
                await _dbContext.SaveChangesAsync();
            }
        }
        //------------------------------Image Post method----------------------//
        public bool Add(FishFarms fishFarms)
        {
            try
            {
                _dbContext.FishFarms.Add(fishFarms);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
