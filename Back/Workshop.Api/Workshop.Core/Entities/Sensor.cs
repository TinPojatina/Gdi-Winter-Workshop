using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Workshop.Core.Entities
{
    public class Sensor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long SensorSerial{ get; set; }
        public SensorType Type{ get; set; }
        public long SensorTypeId { get; set; }
    }
}