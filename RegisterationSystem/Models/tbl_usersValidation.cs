using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegisterationSystem.Models
{
    public class tbl_usersValidation
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [MetadataType (typeof( tbl_usersValidation))]
        public partial class tbl_users
        {
        }
    }
}