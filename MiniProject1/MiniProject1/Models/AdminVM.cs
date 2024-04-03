using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniProject1.Models
{
    public class AdminVM
    {
        [Required(ErrorMessage ="Username required")]
        [EmailAddress(ErrorMessage = "EmailId required")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}