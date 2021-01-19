using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VidlyApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage =  "Please enter the customers legal name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; } //This is the “navigation property” - allowing us to navigate from one object to another. Useful when we load the customer object, we load the MembershipType object too.

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; } //This is just a reference to the MembershipType object, not the object itself - essentially the foreign key. Entity FW recognises this convention, and creates this as a foreign key in the DB table.

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}