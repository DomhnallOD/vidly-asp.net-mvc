using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyApp.Models;

namespace VidlyApp.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; } //This is just a reference to the MembershipType object, not the object itself - essentially the foreign key. Entity FW recognises this convention, and creates this as a foreign key in the DB table.

        public MembershipTypeDto MembershipType { get; set; } //We need to call this property MembershipType (not MembershipTypeDto), as the properties need to have the same names between the model classes (DB models) and the DTO classe for the AutoMapper. Otherwise the value will be null because it wont see what to map it to.

        [Min18YearsIfAMemberDto]
        public DateTime? BirthDate { get; set; }
    }
}
