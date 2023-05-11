using FishFarm.Models;
using FishFarm.Models.Dtos;

namespace FishFarm.Repository.WorkersRepo
{
    public interface IWorkerRepository
    {
        Task<IEnumerable<Workers>> GetWorkers();
        Task<Workers> GetWorkerById(int id);
        Task<Workers> PostWorker(Workers workers);
        Task PutWorkers(int id, Workers workers);
        Task DeleteWorker(int id);
        Task<IEnumerable<WorkersDto>> GetWorkersDto();
        Task<Workers> PostWorkerDto(WorkerDtoEdit workersDtoEdit);
        Task PutWorkersDto(int idd, WorkerDtoEdit workersDtoEdit);
    }
}
