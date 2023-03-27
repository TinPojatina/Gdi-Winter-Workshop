using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Workshop.Core.Entities
{
    public class SensorType
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Sensor> Sensors{ get; set; }
    }
}