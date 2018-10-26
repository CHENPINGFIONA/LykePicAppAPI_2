﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LykePicApp.Model
{
    public class UserPost
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid PostId { get; set; }

        public Guid UserId { get; set; }

        public string Picture { get; set; }

        public DateTime CreatedDate { get; set; }

        public byte[] Timestamp { get; set; }
    }
}