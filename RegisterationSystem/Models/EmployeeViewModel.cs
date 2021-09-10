using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegisterationSystem.Models
{
    public class EmployeeViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public Nullable<bool> InterestedInCSharp { get; set; }
        public Nullable<bool> InterestedInJava { get; set; }
        public Nullable<bool> InterestedInPython { get; set; }

       

    }
}