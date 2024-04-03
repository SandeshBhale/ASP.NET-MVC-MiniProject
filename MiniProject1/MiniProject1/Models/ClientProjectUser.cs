using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniProject1.Models
{
    public class ClientProjectUser
    {
        [Key]
        public Int64 UserId { get; set; }
        [Required(ErrorMessage ="Firstname required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Lastname required")]
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get; set; }


        [ForeignKey("ClientProject")]
        public Int64 ProjectId { get; set; }
        public virtual ClientProject ClientProject { get; set; }
        public string Address { get; set; }
        [EmailAddress(ErrorMessage ="Email id required")]
        public string EmailId { get; set; }
        [Required(ErrorMessage ="Mobile No required")]
        public string MobileNo { get; set; }
        //[Required(ErrorMessage ="UserName required")]
        public string UserName { get; set; }
        //[Required(ErrorMessage ="Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime RegistrationDate 
        {
            get
            {
                return DateTime.Now;
            } 
        }
        public bool IsActive { get; set; }
    }

}