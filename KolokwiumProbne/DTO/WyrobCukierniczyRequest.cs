﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumProbne.DTO
{
    public class WyrobCukierniczyRequest
    {
        [Required]
        public int Ilosc { get; set; }
        [Required]
        [MaxLength(200)]
        public string Wyrob { get; set; }
        [MaxLength(300)]
        public string Uwagi { get; set; }

    }
}
