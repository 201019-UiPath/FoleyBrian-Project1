﻿using System;
using System.ComponentModel.DataAnnotations;


namespace ManagerUI.Models

{
    public class Admin
    {
        [Key]
        public string ID { get; set;}
        public string username { get; set; }
        public string password { get; set; }
    }
}
