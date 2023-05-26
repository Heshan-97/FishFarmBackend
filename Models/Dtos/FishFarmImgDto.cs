using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishFarm.Models.Dtos
{
    //************fish farm post method with img upload***********
    public class FishFarmImgDto
    {
        public string? FarmName { get; set; }
        public string? FarmPictureUrl { get; set; }
        public bool BargeAvailability { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        
        
    }
}
