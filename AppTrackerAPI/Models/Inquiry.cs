using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppTrackerAPI.Models
{
    [Table("Inquries", Schema = "gov")]
    public class Inquiry
    {
        public int Id { get; set; }
        public int? ApplicationId { get; set; }
        public string SendToPerson { get; set; }
        public string SendToRole { get; set; }
        public int? SendToPersonId { get; set; }
        public string Subject { get; set; }

        [Column("Inquiry")]
        public string InquiryText { get; set; } 

        public string Response { get; set; }
        public DateTime? AskedDt { get; set; }
        public DateTime? CompletedDt { get; set; }
    }

}

