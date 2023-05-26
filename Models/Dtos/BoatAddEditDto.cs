using System.ComponentModel.DataAnnotations;

namespace FishFarm.Models.Dtos
{
    //**********BoatAddEditDto use for Add new boat and edit boat details************
    public class BoatAddEditDto
    {
        public int BoatId { get; set; }
        public string? BoatName { get; set; }
        public double GpsPosition { get; set; }
        public int NoOfCages { get; set; }
        public int? FishFarmsFarmId { get; set; }
    }
}
