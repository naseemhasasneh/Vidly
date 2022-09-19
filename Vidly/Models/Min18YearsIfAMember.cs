using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        //this class is for a custom validation by our logic
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
           
            if (customer.MemberShipTypeId ==MemberShipType.Unknown ||customer.MemberShipTypeId==MemberShipType.PayAsYouGo) //if the customer select pay as you go or not select anything ,so you don't need to check the birthdate att..
            {
                return ValidationResult.Success;
            }
            if (customer.Birthdate == null)
            {
                return new ValidationResult("birthdate is requried");
            }
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            if (age >= 18)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("customer should be at least 18 years old to go on a membership");
            }
            
        }
    }
}