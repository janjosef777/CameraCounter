﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CameraCounter.Models
{
    public class ProductionOrder
    {
        [Key]
        public int ID { get; set; }
        public int CamerasMade { get; set; }
        public int CamerasFailed { get; set; }
        public DateTime DateDone { get; set; }
        [ForeignKey("Line")]
        public int LineID { get; set; }
        public Line Line { get; set; }

    }
}
