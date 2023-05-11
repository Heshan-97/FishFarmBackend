
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishFarm.Models
{
    public class Workers
    {
        [Key]
        public int WorkerId { get; set; }
       
        [StringLength(100)]
        public string? PictureUrl { get; set; }
        public  int Age { get; set; }
        
        [StringLength(50)]
        public string? FirstName { get; set; }
        
        [StringLength(50)]
        //[Column(TypeName = "nvarchar(250)")]
        public string? MiddleName { get; set; }
        
        [StringLength(50)]
        public string? LastName { get; set; }
        
        [StringLength(50)]

        public string? Email { get; set; }
       
        public DateTime CertifiedDatePeriod { get; set; }
        
        public string? CrewRole { get; set; }
        
        [StringLength(50)]
        public string? WorkerPosition { get; set; }
        
        [StringLength(50)]
        [ForeignKey("FishFarms")]
        public int? FishFarmsFarmId { get; set; }
        public FishFarms? FishFarms { get; set; }


    }
}
