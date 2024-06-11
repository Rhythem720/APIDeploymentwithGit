using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurfBooking.Domain.Entities
{
    public class Booking
    {
        [Key]
        public int BookingId { set; get; }

        [Required] 
        public int UserId { set; get; }
        [Required]
        public int TurfCourtId { set; get; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime BookingTime { set; get; }
        [Required]

        public string BookingDuration { set; get; } = string.Empty;
        [JsonIgnore]
         [ForeignKey("UserId")]
       public virtual User? Userdetails { set; get; }
        [JsonIgnore]
        [ForeignKey("TurfCourtId")]
        public virtual TurfDetails? TurfDetails { get; set; }
    }
}
