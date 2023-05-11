namespace FishFarm.Models.Dtos
{
    public class WorkerDtoEdit
    {
        public int WorkerId { get; set; }

        public string? PictureUrl { get; set; }
        public int Age { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        public string? Email { get; set; }

        public DateTime CertifiedDatePeriod { get; set; }

        public string? CrewRole { get; set; }
        public string? WorkerPosition { get; set; }
        public int? FishFarmsFarmId { get; set; }
       
    }
}
