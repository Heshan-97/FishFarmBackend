using System.ComponentModel.DataAnnotations;

namespace FishFarm.Models.Dtos
{
    public class FishFarmDto
    {
        
        public int FarmId { get; set; }
        public string? FarmName { get; set; }
        public string? FarmPictureUrl { get; set; }
        public bool BargeAvailability { get; set; }
    }
}
