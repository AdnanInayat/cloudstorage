﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataUpload.WebApi.Models
{
    public class IdentityModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
