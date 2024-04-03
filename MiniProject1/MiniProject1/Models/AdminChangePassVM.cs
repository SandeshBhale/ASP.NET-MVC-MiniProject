using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniProject1.Models
{
    public class AdminChangePassVM
    {
        public Int64 AdminId { get; set; }

        [Required(ErrorMessage ="Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="Confirm Password Required")]
        [Compare("Password" , ErrorMessage ="Password Not Match")]
        [DataType(DataType.Password)]
        public string ConfPassword { get; set; }
    }
}