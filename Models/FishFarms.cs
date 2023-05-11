using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishFarm.Models
{
    //[Table("FishFarm")]
    public class FishFarms
    {
        [Key]
        public int FarmId { get; set; }
       
        [StringLength(50)]
        public string? FarmName { get; set; }

       
        [StringLength(100)]
        public string? FarmPictureUrl { get; set; } 
        public bool BargeAvailability { get; set; }
        

       //[ForeignKey(nameof(Boats))]
        //public ICollection<Boats>? BoatId { get; set; }
        //public ICollection<Workers>? WorkerId { get; set; }
    }
}
