using AutoMapper;

namespace FishFarm.Models.Dtos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Workers, WorkersDto>();       //To get workers details
            CreateMap<Boats, BoatDto>();            //BoatDto use for get boat list
            CreateMap<FishFarms, FishFarmImgDto>(); //
            CreateMap<WorkerDtoEdit, Workers>();    ////WorkerDtoEdit use for Add new worker and edit worker details
            CreateMap<BoatAddEditDto, Boats>();     //BoatAddEditDto use for Add new boat and edit boat details
            CreateMap<FishFarms, FishFarmDto>();    //To get fishfarm details
            CreateMap<FishFarmImgDto, FishFarms>(); //fish farm post method with img upload
            CreateMap<WorkersImgDto, Workers>();    // Workers Post method with img upload
        }
    }
}
