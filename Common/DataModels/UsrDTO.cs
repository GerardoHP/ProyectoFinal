﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.DataModels
{
    public class UsrDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string Mail { get; set; }
        public Nullable<bool> Verified { get; set; }
    }
}