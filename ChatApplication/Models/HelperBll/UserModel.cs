﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatApplication.Models.HelperBll
{
    public class UserModel
    {
        public int userid { get; set; }
      
        public string email { get; set; }
       
        public string mobile { get; set; }
        
        public string password { get; set; }
        
        public string confirmpassword { get; set; }
       
        public string dob { get; set; }
    }
}