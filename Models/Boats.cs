using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishFarm.Models
{
    public class Boats
    {
        [Key]
        public int BoatId { get; set; }
        
        [StringLength(50)]
        public string? BoatName { get; set; }
        public double GpsPosition { get; set; }
        public int NoOfCages { get; set; }
        [StringLength(50)]
        [ForeignKey("FishFarms")]
        public int? FishFarmsFarmId { get; set; }
        public FishFarms? FishFarms { get; set; }
    }
}
