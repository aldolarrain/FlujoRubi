﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductor.Models
{
    public class Data
    {
        [Key]
        public string NameDevice { get; set; }  //prop tab tab
        
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime EventDate { get; set; }
        
        [Required]
        public string Event { get; set; }

    }
}
