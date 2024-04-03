using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antlr.Runtime;

namespace MiniProject1.Models
{
    public class Admin
    {
        [Key]
        public Int64 AdminId { get; set; }
        [Required(ErrorMessage ="Name Required")]
        public string AdminName { get; set; }
        [EmailAddress(ErrorMessage ="EmailId Required")]
        public string EmailId { get; set; }
        [Required(ErrorMessage ="Mobile No required")]
        public string MobileNo { get; set; }
        //[Required(ErrorMessage ="Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}