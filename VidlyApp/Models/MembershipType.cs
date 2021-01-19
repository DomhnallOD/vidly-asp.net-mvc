using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyApp.Models
{
    public class MembershipType
    {
        public String Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public byte Id { get; set; } //The “key” which maps to the primary key on the table in the DB

        public static readonly byte Unknown = 0; //Get rid of magic numbers in the Min18YearsIfAMember validation class
        public static readonly byte PAYG = 1; 

    }
}