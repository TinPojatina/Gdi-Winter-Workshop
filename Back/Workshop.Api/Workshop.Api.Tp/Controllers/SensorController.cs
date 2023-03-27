using Workshop.Infrastructure;
using Workshop.Api.Tp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workshop.Core.Entities;

#nullable disable

namespace Workshop.Api.Tp.Controllers
{
    public class SensorController : ControllerBase
    {
        
        public readonly WorkshopInfrastructureDbContext _dbContext;
        private readonly HttpClient _httpClient;
        public SensorController(
            WorkshopInfrastructureDbContext dbContext, 
            HttpClient httpClient)
        {
            _dbContext = dbContext;
            _httpClient = httpClient;
        }

        [HttpGet("Get-Sensors")]
        public async Task<ActionResult<List<SensorModel>>> GetSensor()
        {
            var sensors = await _dbContext.Sensors.Include(
                x=>x.Type)
                .Select(y => new SensorModel(
                y.Id, 
                y.Name, 
                y.SensorSerial, 
                y.Type.Id, 
                y.Type.Name
                ))
                .ToListAsync();

                return Ok(sensors);
                }

        [HttpPost("Add-Sensors")]
        public async Task<ActionResult<SensorModel>> AddSensor([FromBody] SensorModel sensorModel)
        {
            var sensor = new Sensor
            {
                Name = sensorModel.Name,
                SensorSerial= sensorModel.SensorSerial,
                SensorTypeId = sensorModel.TypeId
            };

            _dbContext.Sensors.Add(sensor);
            await _dbContext.SaveChangesAsync();

            return Ok(
                new SensorModel(
                    sensorModel.Id,
                    sensorModel.Name,
                    sensorModel.SensorSerial,
                    sensorModel.TypeId,
                    sensorModel.SensorTypeName
                    )
                );
        }

        [HttpDelete("Remove-Sensor/{id}")]
        public async Task<ActionResult> DeleteType(long id)
        {
            var deletedRow = await _dbContext.SensorTypes.FindAsync(id);
            _dbContext.Remove(deletedRow);
            _dbContext.SaveChanges();
            return Ok("Deleted.");
        }

        [HttpPost("Alter-Sensor/{id}")]
        public async Task<ActionResult<SensorTypeModel>> AlterSensorType(long id, string newName, long newSerial, long newType)
        {
            var modifyRow = new Sensor
            {
                Id = id,
                Name = newName,
                SensorSerial = newSerial,
                SensorTypeId = newType
            };
            _dbContext.Update(modifyRow);
            _dbContext.SaveChanges();
            return Ok(modifyRow);
        }

        [HttpPost("Check")]
        public async Task<IActionResult> Check()
        {
            return this.Ok();
        }
    }
}