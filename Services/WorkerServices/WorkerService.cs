using AutoMapper;
using FishFarm.Models;
using FishFarm.Models.Dtos;
using FishFarm.Repository.WorkersRepo;
using Microsoft.AspNetCore.Mvc;

namespace FishFarm.Services.WorkerServices
{
    public class WorkerService : IWorkerService
    {

        private readonly IWorkerRepository _IWorkerRepository;
        private readonly IHostEnvironment _environment;
        private readonly IMapper _mapper;

        public WorkerService(IWorkerRepository workerRepository, IHostEnvironment env, IMapper mapper)
        {
            _IWorkerRepository = workerRepository;
            _environment = env;
            _mapper = mapper;

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

        //------------------------------Image Post method----------------------//
        public async Task<ActionResult> SaveImage(WorkersImgDto workersImgDto)
        {
            try
            {
                var contentPath = this._environment.ContentRootPath;
                //var path = Path.Combine(contentPath, "Uploads");
                var path = Path.Combine(contentPath, "D:\\Fish_Farm_Frontend\\fish-farm-app\\public\\imgWorker");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //check the allowed extentions
                var ext = Path.GetExtension(workersImgDto.ImageFile.FileName);
                var allowedExtentions = new string[] { ".jpg", ".png", ".jpeg" };
                if (!allowedExtentions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extentions are allowed", string.Join(",", allowedExtentions));
                    //return new Tuple<int, string>(0, msg);
                    return new OkResult();
                }
                string uniqueString = Guid.NewGuid().ToString();
                // We are trying to crate a unique filename here
                var newFileName = uniqueString + ext;
                var puclicImgPath = "imgWorker/" + newFileName;
                var fileWithPath = Path.Combine(path, newFileName);
                var stream = new FileStream(fileWithPath, FileMode.Create);
                workersImgDto.ImageFile?.CopyTo(stream);
                stream.Close();
                //return new Tuple<int, string>(1, fileWithPath);
                workersImgDto.PictureUrl = puclicImgPath;
                (int, string) t = (1, fileWithPath);
                var workersImgAddTo = _mapper.Map<Workers>(workersImgDto);
                var workersResult = _IWorkerRepository.Add(workersImgAddTo);
                var status = new Status();
                if (workersResult)
                {
                    status.StatusCode = 1;
                    status.Messsage = "Added Successfully";
                }
                else
                {
                    status.StatusCode = 0;
                    status.Messsage = "Error on adding img";
                }


                return new OkResult();
            }
            catch (Exception ex)
            {
                //return new Tuple<int, string>(0, "Error has Occured" + ex.Message);
                return new OkResult();
            }
        }
    }
}
