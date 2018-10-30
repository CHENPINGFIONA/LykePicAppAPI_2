using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LykePicApp.DAL
{
    public class UserLogin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid LoginId { get; set; }

        public string UserName { get; set; }

        public string IPV4Address { get; set; }

        public bool IsSuccessful { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}