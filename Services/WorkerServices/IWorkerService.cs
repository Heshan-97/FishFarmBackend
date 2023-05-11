using FishFarm.Models;
using FishFarm.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FishFarm.Services.WorkerServices
{
    public interface IWorkerService
    {
        Task<ActionResult<IEnumerable<Workers>>> GetWorkers();
        Task<ActionResult<Workers>> GetWorkerById(int id);
        Task<ActionResult<Workers>> PostWorker(Workers workers);
        Task<IActionResult> PutWorkers(int id, Workers workers);
        Task<ActionResult> DeleteWorker(int id);
        Task<ActionResult<IEnumerable<WorkersDto>>> GetWorkersDto();
        Task<ActionResult<Workers>> PostWorkerDto(WorkerDtoEdit workersDtoEdit);

        Task<IActionResult> PutWorkersDto(int idd, WorkerDtoEdit workersDtoEdit);
    }
}
