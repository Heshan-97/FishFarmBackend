using FishFarm.Models;
using FishFarm.Models.Dtos;
using FishFarm.Repository.WorkersRepo;
using Microsoft.AspNetCore.Mvc;

namespace FishFarm.Services.WorkerServices
{
    public class WorkerService : IWorkerService
    {

        private readonly IWorkerRepository _IWorkerRepository;
        public WorkerService(IWorkerRepository workerRepository)
        {
            _IWorkerRepository = workerRepository;
        }
        public async Task<ActionResult<IEnumerable<Workers>>> GetWorkers()
        {
            var result = await _IWorkerRepository.GetWorkers();
            if (result == null)
            {
                return new StatusCodeResult(404);
            }
            return new OkObjectResult(result);
        }
        public async Task<ActionResult<Workers>> GetWorkerById(int id)
        {
            var worker = await _IWorkerRepository.GetWorkerById(id);
            if (worker == null)
            {
                return new StatusCodeResult(404);
            }
            return new OkObjectResult(worker);
        }
        public async Task<ActionResult<Workers>> PostWorker(Workers workers)
        {
            return await _IWorkerRepository.PostWorker(workers);
        }

        public async Task<IActionResult> PutWorkers(int id, Workers workers)
        {
            await _IWorkerRepository.PutWorkers(id, workers);
            return new ObjectResult(workers) { StatusCode = 200 };
        }
        public async Task<ActionResult> DeleteWorker(int id)
        {
            var workers = await _IWorkerRepository.GetWorkerById(id);
            if (workers == null)
            {
                //return NotFound();
                return new StatusCodeResult(404);
            }
            await _IWorkerRepository.DeleteWorker(id);
            return new OkResult();
        }
        //-----------------------------------------------------------------------------dto
        public async Task<ActionResult<IEnumerable<WorkersDto>>> GetWorkersDto()
        {
            try
            {
                var result = await _IWorkerRepository.GetWorkersDto();
                if (result == null)
                {
                    return new List<WorkersDto>();
                }
                return new OkObjectResult(result);
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }
        public async Task<ActionResult<Workers>> PostWorkerDto(WorkerDtoEdit workersDtoEdit)
        {
            return await _IWorkerRepository.PostWorkerDto(workersDtoEdit);
        }

        public async Task<IActionResult> PutWorkersDto(int idd, WorkerDtoEdit workersDtoEdit)
        {
            await _IWorkerRepository.PutWorkersDto(idd, workersDtoEdit);
            return new ObjectResult(workersDtoEdit) { StatusCode = 200 };
        }
    }
}
