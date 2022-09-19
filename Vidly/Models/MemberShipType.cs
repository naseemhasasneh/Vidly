using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MemberShipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurtionInMonths { get; set; }
        public byte DiscountRate { get; set; }
        [Required]
        public string Name { get; set; } 
        // these static varibles to aviod magic numbers in our custom validation.
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1; 

    }
}