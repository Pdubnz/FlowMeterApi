using System;
using System.Collections.Generic;
using System.Text;

namespace FlowMeterData.Library.Models
{
    public class FlowMeterReadingModel
    {
        public int MeterReadingId { get; set; } = -1;
        public int FlowMeterId { get; set; } = -1;
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public float Value { get; set; } = 0;
    }
}
