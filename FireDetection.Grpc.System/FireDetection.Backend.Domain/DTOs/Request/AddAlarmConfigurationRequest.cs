﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDetection.Backend.Domain.DTOs.Request
{
    public class AddAlarmConfigurationRequest
    {
        [Range(0,100)]
        public decimal Start { get; set; }

        [Range(0, 100)]
        public decimal End { get; set; }
     
    }
}
