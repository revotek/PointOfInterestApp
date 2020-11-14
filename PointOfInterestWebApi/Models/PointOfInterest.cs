﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfInterestWebApi.Models
{
    [Table("poi_tb")]
    public class PointOfInterest
    {
        public int Id {get;set;}
        public string Name {get;set; }
        public string Description {get;set; }
        public string Address {get;set;}
        public string Image {get;set;}
        public decimal? Latitude {get;set;}
        public decimal? Longitude {get;set;}
    }
}
