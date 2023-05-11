using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishFarm.Models.Dtos
{
    public class FishFarmImgDto
    {
        

        public string? FarmName { get; set; }
        public string? FarmPictureUrl { get; set; }
        public bool BargeAvailability { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        
        
    }
}
