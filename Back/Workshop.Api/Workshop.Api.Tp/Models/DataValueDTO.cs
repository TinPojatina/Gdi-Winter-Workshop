using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Core.Entities;

namespace Workshop.Api.Tp.Models
{
    public record DataValueModel(
            long Id,
            long ReturnedValue,
            long SensorId
        );
}