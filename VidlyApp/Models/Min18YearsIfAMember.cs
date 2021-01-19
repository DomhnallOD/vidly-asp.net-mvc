using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyApp.Dtos;

namespace VidlyApp.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //This will all get called once the user has clicked submit, i.e. the fowm has created a new customer object using the users input data
            var customer = (Customer)validationContext.ObjectInstance; //Get the customer object from the ValidationContext - the object that the form has written to.

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PAYG) //If PAYG customer, we don't need to check age, so allow success
                return ValidationResult.Success;

            if (customer.BirthDate == null) //Then, in all other cases, ensure BirthDate is not null
                return new ValidationResult("Birth date is required.");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year; //Then, calculate their age as entered into the form

            return (age >= 18) //Condition
                ? ValidationResult.Success //If true
                : new ValidationResult("Customer must be over 18 for this payment plan."); //Else
        }
    }
}