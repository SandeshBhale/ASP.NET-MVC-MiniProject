using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace MiniProject1.Models
{
    public class Client
    {
        [Key]
        public Int64 ClientId { get; set; }
        [Required(ErrorMessage ="Client Name Required")]
        public string ClientName { get; set; }
        public string Address { get; set; }
        [EmailAddress(ErrorMessage ="EmailId required")]
        public string EmailId { get; set; }
        [Required(ErrorMessage ="Mobile No required")]
        public string MobileNo { get; set; }
    }
}