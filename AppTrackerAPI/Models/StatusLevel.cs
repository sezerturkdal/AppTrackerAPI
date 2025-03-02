using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppTrackerAPI.Models
{
    [Table("StatusLevel", Schema = "dbo")]
    public class StatusLevel
    {
        public int Id { get; set; }
        public string? StatusName { get; set; }
    }

}

