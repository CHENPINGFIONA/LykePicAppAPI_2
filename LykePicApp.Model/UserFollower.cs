using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LykePicApp.Model
{
    public class UserFollower
    {
        [Key, Column(Order = 0)]
        public Guid UserId { get; set; }

        [Key, Column(Order = 1)]
        public Guid FollowerUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public byte[] Timestamp { get; set; }
    }
}