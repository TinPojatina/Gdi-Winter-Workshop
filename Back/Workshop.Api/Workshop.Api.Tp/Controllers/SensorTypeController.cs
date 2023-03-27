using Workshop.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workshop.Core.Entities;
using Workshop.Api.Tp.Models;
using System;
using System.Runtime.CompilerServices;


#nullable disable

namespace Workshop.Api.Tp.Controllers
{
    public class SensorTypeController : ControllerBase
    {
        private readonly WorkshopInfrastructureDbContext _dbContext;

        public SensorTypeController(
            WorkshopInfrastructureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Get-Sensor-Types")]
        public async Task<ActionResult<List<SensorTypeModel>>> GetsenSensorTypes()
        {
            var types = await _dbContext.SensorTypes.Select(x => new SensorTypeModel(
                x.Id,
                x.Name
                ))
                .ToListAsync();

            return Ok(types);
        }

        [HttpGet("Get-Sensor-Type/{typeId}")]
        public async Task<ActionResult<SensorTypeModel>> GetSensorType(long typeId)
        {
            var result = _dbContext.SensorTypes.FindAsync(typeId);

            return Ok(result);
        }


        [HttpPost("Add-Sensor-Type")]
        public async Task<ActionResult<List<SensorTypeModel>>> AddSensorType([FromBody] SensorTypeModel sensorType)
        {
            var sensortype = new SensorType
            {
                Name = sensorType.Name
            };
            _dbContext.SensorTypes.Add(sensortype);
            await _dbContext.SaveChangesAsync();
            return Ok(new SensorTypeModel(sensorType.SensorTypeId, sensorType.Name));
        }

        [HttpDelete("Remove-Sensor-Type/{sensorTypeId}")]
        public async Task<ActionResult> DeleteType(long sensorTypeId)
        {
            var deletedRow = await _dbContext.SensorTypes.FindAsync(sensorTypeId);
            _dbContext.Remove(deletedRow);
            _dbContext.SaveChanges();
            return Ok("Deleted.");
        }

        [HttpPost("Alter-Type/{sensorTypeId}")]
        public async Task<ActionResult<SensorTypeModel>> AlterSensorType(long sensorTypeId, string newName)
        {
            var modifyRow = new SensorType
            {
                Id = sensorTypeId,
                Name = newName
            };
            _dbContext.Update(modifyRow);
            _dbContext.SaveChanges();
            return Ok(modifyRow);
        }
    }
};