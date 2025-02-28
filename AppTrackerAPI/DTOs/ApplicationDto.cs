using System;
namespace AppTrackerAPI.DTOs
{
    public class ApplicationDto
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
        public StatusLevelDto? StatusLevel { get; set; }
        public List<InquiryDto>? Inquiries { get; set; }
        public int? StatusId { get; set; }
        public string? Notes { get; set; }
        public DateTime? Modified { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public class InquiryDto
    {
        public int Id { get; set; }
        public int? ApplicationId { get; set; }
        public string? SendToPerson { get; set; }
        public string? SendToRole { get; set; }
        public int? SendToPersonId { get; set; }
        public string? Subject { get; set; }
        public string? InquiryText { get; set; }
        public string? Response { get; set; }
        public DateTime? AskedDt { get; set; }
        public DateTime? CompletedDt { get; set; }
    }

    public class StatusLevelDto
    {
        public int Id { get; set; }
        public string? StatusName { get; set; }
    }

}

