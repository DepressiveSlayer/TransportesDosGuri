using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TransportesDosGuri.Core.Application.DTOs;
using TransportesDosGuri.Core.Application.ServiceContracts;

namespace TransportesDosGuri.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class FlightSeatController : CustomControllerBase
    {
        private readonly IFlightSeatService _flightSeatService;

        public FlightSeatController(IFlightSeatService flightSeatService)
        {
            _flightSeatService = flightSeatService;
        }

        /// <summary>
        /// Endpoint to GET ALL data stored in the FlightSeat Table
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAll = await _flightSeatService.GetAllAsync();

            return Ok(getAll);
        }

        /// <summary>
        /// Endpoint to GET BY ID a specific row stored in the FlightSeat Table
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var getById = await _flightSeatService.GetByIdAsync(id);

            return Ok(getById);
        }

        /// <summary>
        /// Endpoint to CREATE a row of information in the FlightSeat Table
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(FlightSeatDTO flightSeat)
        {
            var create = await _flightSeatService.CreateAsync(flightSeat);

            return Ok("Data Saved");
        }

        /// <summary>
        /// Endpoint to UPDATE BY ID a row stored in the FlightSeat Table
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, FlightSeatDTO flightSeat)
        {
            var update = await _flightSeatService.UpdateAsync(id, flightSeat);

            return Ok("Data Updated");
        }

        /// <summary>
        /// Endpoint to DELETE BY ID a row stored in the FlightSeat Table
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var delete = await _flightSeatService.DeleteAsync(id);

            return Ok("Data Deleted");
        }
    }
}
