using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LykePicApp.Model
{
    public class UserFollower
    {
        public Guid UserId { get; set; }

        public Guid FollowerUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public byte[] Timestamp { get; set; }
    }
}