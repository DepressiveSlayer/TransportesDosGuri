using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TransportesDosGuri.Core.Application.DTOs;
using TransportesDosGuri.Core.Application.ServiceContracts;

namespace TransportesDosGuri.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class ScheduleController : CustomControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        /// <summary>
        /// Endpoint to GET ALL data stored in the Schedule Table
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAll = await _scheduleService.GetAllAsync();

            return Ok(getAll);
        }

        /// <summary>
        /// Endpoint to GET BY ID a specific row stored in the Schedule Table
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var getById = await _scheduleService.GetByIdAsync(id);

            return Ok(getById);
        }

        /// <summary>
        /// Endpoint to CREATE a row of information in the Schedule Table
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(ScheduleDTO schedule)
        {
            var create = await _scheduleService.CreateAsync(schedule);

            return Ok("Data Saved");
        }

        /// <summary>
        /// Endpoint to UPDATE BY ID a row stored in the Schedule Table
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, ScheduleDTO schedule)
        {
            var update = await _scheduleService.UpdateAsync(id, schedule);

            return Ok("Data Updated");
        }

        /// <summary>
        /// Endpoint to DELETE BY ID a row stored in the Schedule Table
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var delete = await _scheduleService.DeleteAsync(id);

            return Ok("Data Deleted");
        }
    }
}
