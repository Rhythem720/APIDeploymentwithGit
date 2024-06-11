using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.Domain.Entities.Enums;

namespace TurfBooking.Domain.Entities
{
    public class TurfDetails
    {
        [Key]
        public int TurfId { get; set; }
        [Required]
        [Display(Name = "Turf Name")]

        public string TurfName { get; set; }

        [Required]
        [Display(Name = "Turf Description")]
        public string TurfDescription { get; set; }
        [Required]
        [MaxLength(50)]
        public string TurfLocation { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string TurfContactNumber { get; set; }

        [Required]
        [Display(Name = "Turf Status")]
        public TurfStatus CourtStatus { get; set; }
    }
}
