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
    public class User
    {
        [Key]
        
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Your Email is not valid.")]
        public string UserEmail { get; set; } = string.Empty ;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PhoneNo { get; set; } = string.Empty;
        [Required]
        [MaxLength(1)]
        
        public string Gender { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Booking>? Bookings { get; set; }

    }
}
