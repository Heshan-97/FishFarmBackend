using System.ComponentModel.DataAnnotations;

namespace FishFarm.Models.Dtos
{
    //***********BoatDto use for get boat list*********** 
    public class BoatDto
    {
        public int BoatId { get; set; }

        [StringLength(50)]
        public string? BoatName { get; set; }
        public double GpsPosition { get; set; }
        public int NoOfCages { get; set; }
        public int? FishFarmsFarmId { get; set; }
        public FishFarmDto? FishFarms { get; set; }
    }
}
