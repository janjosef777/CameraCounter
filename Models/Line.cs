using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CameraCounter.Models
{
    public class Line
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int DailyTarget { get; set; }
        public ICollection<ProductionOrder> ProductionOrders { get; set; }
        public ICollection<Issue> Issues { get; set; }

    }
}
