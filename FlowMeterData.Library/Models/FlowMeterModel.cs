using System;
using System.Collections.Generic;
using System.Text;

namespace FlowMeterData.Library.Models
{
    public class FlowMeterModel
    {
        public int FlowMeterId { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
