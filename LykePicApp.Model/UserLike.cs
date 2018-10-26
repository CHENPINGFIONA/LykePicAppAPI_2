using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LykePicApp.Model
{
    public class UserLike
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public Guid LikeId { get; set; }

        public Guid UserId { get; set; }

        public Guid PostId { get; set; }

        public DateTime CreatedDate { get; set; }

        public byte[] Timestamp { get; set; }
    }
}