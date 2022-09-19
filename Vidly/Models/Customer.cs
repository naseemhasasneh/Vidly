using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250)] //annotations to name proprity
        public string Name { get; set; }
        public bool IsSubscibedToNewsLetter { get; set; }
        [Display(Name = "membershiptype")]
        public MemberShipType MemberShipType { get; set; }
        [Display(Name = "MemberShipType")]
        public byte MemberShipTypeId { get; set; } //forgin key 
        [Display(Name = "DateOfBirth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

    }
}