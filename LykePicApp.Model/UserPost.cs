using System;

namespace LykePicApp.Model
{
    public class UserPost
    {
        public Guid PostId { get; set; }

        public Guid UserId { get; set; }

        public string Picture { get; set; }

        public DateTime CreatedDate { get; set; }

        public byte[] Timestamp { get; set; }
    }
}