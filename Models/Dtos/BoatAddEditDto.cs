using System.ComponentModel.DataAnnotations;

namespace FishFarm.Models.Dtos
{
    public class BoatAddEditDto
    {
        public int BoatId { get; set; }
        public string? BoatName { get; set; }
        public double GpsPosition { get; set; }
        public int NoOfCages { get; set; }
        public int? FishFarmsFarmId { get; set; }
    }
}
