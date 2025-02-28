using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppTrackerAPI.Models
{
    [Table("Application", Schema = "gov")]
    public class Application
    {
        public int Id { get; set; }
        public string? AppStatus { get; set; }
        public string? ProjectRef { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectLocation { get; set; }
        public DateTime? OpenDt { get; set; }
        public DateTime? StartDt { get; set; }
        public DateTime? CompletedDt { get; set; }
        public decimal? ProjectValue { get; set; }

        [ForeignKey("StatusId")]
        public StatusLevel? StatusLevel { get; set; }

        [ForeignKey("ApplicationId")]
        public List<Inquiry>? Inquiries { get; set; }

        public int? StatusId { get; set; }

        public string? Notes { get; set; }
        public DateTime? Modified { get; set; }
        public bool? IsDeleted { get; set; }
    }


}

