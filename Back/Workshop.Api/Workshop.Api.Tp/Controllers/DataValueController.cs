using Workshop.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Workshop.Api.Tp.Models;
using Workshop.Core.Entities;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

#nullable disable

namespace Workshop.Api.Tp.Controllers
{
    public class DataValueController : ControllerBase
    {
        public readonly WorkshopInfrastructureDbContext _dbContext;

        public DataValueController(
            WorkshopInfrastructureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("Add-Inputs")]
        public async Task<ActionResult<DataValueModel>> AddDataInput([FromBody] DataValueModel dataValueModel)
        {
            var value = new DataValue
            {
                ReturnedValue = dataValueModel.ReturnedValue,
                SensorId = dataValueModel.SensorId
            };
            _dbContext.DataValues.Add(value);
            await _dbContext.SaveChangesAsync();

            return Ok(new DataValueModel(
                dataValueModel.Id,
                dataValueModel.ReturnedValue,
                dataValueModel.SensorId));
        }

        [HttpGet("DataValues/{sensorId}/{index}/{pageSize}")]
        public ActionResult<List<DataValueModel>> GetValues(long sensorId, int index, int pageSize)
        {   
            var items = _dbContext.DataValues
                .Skip((index - 1) * pageSize)
                .Take(pageSize)
                .OrderByDescending(y => y.Id)
                .Where(x => x.SensorId == sensorId)
                .ToList();
            return Ok(items);
        }

        [HttpGet("PaginatedTable/{index}/{pageSize}")]
        public ActionResult<List<DataValueModel>> PaginatedTable(int index, int pageSize) {
            var items = _dbContext.DataValues
                .Skip((index - 1) * pageSize)
                .Take(pageSize)
                .OrderByDescending(x=> x.Id)
                .ToList();
            return Ok(items);

        }
    }
} 
