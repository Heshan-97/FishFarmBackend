using AutoMapper;

namespace FishFarm.Models.Dtos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Workers, WorkersDto>();
            CreateMap<Boats, BoatDto>();
            CreateMap<FishFarms, FishFarmImgDto>();
            CreateMap<WorkerDtoEdit, Workers>();
            CreateMap<BoatAddEditDto, Boats>();
            CreateMap<FishFarms, FishFarmDto>();
            CreateMap<FishFarmImgDto, FishFarms>();
            CreateMap<WorkersImgDto, Workers>();
        }
    }
}
