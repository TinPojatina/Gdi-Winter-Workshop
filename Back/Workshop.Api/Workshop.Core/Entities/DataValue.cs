﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable 
namespace Workshop.Core.Entities
{
    public class DataValue
    {
        public long Id { get; set; }
        public long ReturnedValue { get; set; }
        public Sensor Sensor { get; set; }
        public long SensorId { get; set; }

    }
}
