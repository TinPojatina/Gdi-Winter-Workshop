using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Core.Entities;

namespace Workshop.Api.Tp.Models
{
    public record SensorModel(
            long Id,
            string Name,
            long SensorSerial,
            long TypeId,
            string SensorTypeName
        );
}
