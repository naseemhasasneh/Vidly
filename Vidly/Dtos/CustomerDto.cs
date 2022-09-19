using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250)] //annotations to name proprity
        public string Name { get; set; }
        public bool IsSubscibedToNewsLetter { get; set; }
       
       public byte MemberShipTypeId { get; set; } //forgin key 
        
        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}