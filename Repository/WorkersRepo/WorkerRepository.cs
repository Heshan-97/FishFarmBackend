using AutoMapper;
using FishFarm.Models;
using FishFarm.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FishFarm.Repository.WorkersRepo
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly FishFarmDBContext _dbContext;
        private readonly IMapper _mapper; //Mapping data for dto
        public WorkerRepository(FishFarmDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Workers>> GetWorkers()
        {
            //return await _dbContext.Workers.ToListAsync();
            return await _dbContext.Workers.ToListAsync();
        }
        public async Task<Workers> GetWorkerById(int id)
        {
            return await _dbContext.Workers.FirstOrDefaultAsync(worker => worker.WorkerId == id);
        }
        public async Task<Workers> PostWorker(Workers workers)
        {
            var resultworker = _dbContext.Workers.Add(workers); //  obj of workers class from react js
            await _dbContext.SaveChangesAsync();
            return resultworker.Entity;
        }

        public async Task PutWorkers(int id, Workers workers)
        {
            var existingWorker = await _dbContext.Workers.FindAsync(id);
            if (existingWorker == null)
            {
                throw new InvalidOperationException("Cannot update a worker that does not exist.");
            }
            existingWorker.PictureUrl= workers.PictureUrl;
            existingWorker.Age = workers.Age;
            existingWorker.FirstName = workers.FirstName;
            existingWorker.MiddleName = workers.MiddleName;
            existingWorker.LastName = workers.LastName;
            existingWorker.Email = workers.Email;
            existingWorker.CertifiedDatePeriod = workers.CertifiedDatePeriod;
            existingWorker.CrewRole = workers.CrewRole;
            existingWorker.WorkerPosition = workers.WorkerPosition;
            existingWorker.FishFarmsFarmId = workers.FishFarmsFarmId;

            _dbContext.Entry(existingWorker).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteWorker(int id)
        {
            var workers = await _dbContext.Workers.FindAsync(id);
            if (workers != null)
            {
                _dbContext.Workers.Remove(workers);
                await _dbContext.SaveChangesAsync();
            }
        }
        //-------------------------------------------------------------------------------------------------------DTo 
        
        public async Task<IEnumerable<WorkersDto>> GetWorkersDto()
        {
            var workersdto = await _dbContext.Workers.Include(w => w.FishFarms).ToListAsync();
            return workersdto.Select(w => _mapper.Map<WorkersDto>(w)
            /*{
                PictureUrl = w.PictureUrl,
                Age = w.Age,
                FirstName = w.FirstName,
                MiddleName = w.MiddleName,
                LastName = w.LastName
            }*/);
        }
        public async Task<Workers> PostWorkerDto(WorkerDtoEdit workersDtoEdit)
        {
             var workerAdddto = _mapper.Map<Workers>(workersDtoEdit);
               _dbContext.Workers.Add(workerAdddto);
              await _dbContext.SaveChangesAsync();
              return workerAdddto;
           /* var worker = new Workers
            {
                FirstName = workersDto.FirstName,
                LastName = workersDto.LastName,
                Age = workersDto.Age,
                CertifiedDatePeriod = workersDto.CertifiedDatePeriod,
                CrewRole = workersDto.CrewRole,
                Email = workersDto.Email,
                MiddleName = workersDto.MiddleName,
                PictureUrl = workersDto.PictureUrl,
                WorkerPosition = workersDto.WorkerPosition,
                FishFarmsFarmId = workersDto.FishFarmsFarmId
    };

            var resultworker = _dbContext.Workers.Add(worker);
            await _dbContext.SaveChangesAsync();
            return resultworker.Entity;*/

        }
        public async Task PutWorkersDto(int idd, WorkerDtoEdit workersDtoEdit)
        {
            var workerToUpdate = await _dbContext.Workers.FindAsync(idd);

            if (workerToUpdate == null)
            {
                throw new Exception($"Worker with id {idd} not found");
            }

            // Map the updated properties from the DTO to the existing worker entity
            _mapper.Map(workersDtoEdit, workerToUpdate);

            // Save the changes to the database
            await _dbContext.SaveChangesAsync();
        }

        public bool Add(Workers workers)
        {
            try
            {
                //var fishfarmImgAddTo = _mapper.Map<FishFarms>(fishFarmImgDto);

                _dbContext.Workers.Add(workers);
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
