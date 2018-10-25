using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LykePicApp.Model
{
    public class User
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string ProfilePicture { get; set; }

        public DateTime CreatedDate { get; set; }

        public byte[] Timestamp { get; set; }
    }
}