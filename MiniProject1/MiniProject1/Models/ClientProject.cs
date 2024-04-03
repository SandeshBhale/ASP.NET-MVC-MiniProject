using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniProject1.Models
{
    public class ClientProject
    {
        [Key]
        public Int64 ProjectId { get; set; }
        [Required(ErrorMessage = "Project Name Required")]
        public string ProjectName { get; set; }
        public string LocationAddress { get; set; }
        [Required(ErrorMessage = "City name required")]
        public string LocationCity { get; set; }

        [ForeignKey("Client")]
        public Int64 ClientId { get; set; }
        public virtual Client Client { get; set; }
        public DateTime CreationDate
        {
            get
            {
                return DateTime.Now;
            } 
        }

    }
}