using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TransportesDosGuri.Core.Application.DTOs;
using TransportesDosGuri.Core.Application.ServiceContracts;

namespace TransportesDosGuri.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class SeatController : CustomControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        /// <summary>
        /// Endpoint to GET ALL data stored in the Seat Table
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAll = await _seatService.GetAllAsync();

            return Ok(getAll);
        }

        /// <summary>
        /// Endpoint to GET BY ID a specific row stored in the Seat Table
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var getById = await _seatService.GetByIdAsync(id);

            return Ok(getById);
        }

        /// <summary>
        /// Endpoint to CREATE a row of information in the Seat Table
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(SeatDTO seat)
        {
            var create = await _seatService.CreateAsync(seat);

            return Ok("Data Saved");
        }

        /// <summary>
        /// Endpoint to UPDATE BY ID a row stored in the Seat Table
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, SeatDTO seat)
        {
            var update = await _seatService.UpdateAsync(id, seat);

            return Ok("Data Updated");
        }

        /// <summary>
        /// Endpoint to DELETE BY ID a row stored in the Seat Table
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var delete = await _seatService.DeleteAsync(id);

            return Ok("Data Deleted");
        }
    }
}
