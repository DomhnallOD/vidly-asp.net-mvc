using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyApp.Models;

namespace VidlyApp.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; } //In the view, we dont need any of the functionality of a List (add, remove, update etc.) We just need to iterate over and read the elements. IEnumerable is ideal for this purpose.
        public Customer Customer { get; set; }
    }
}