using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TransportesDosGuri.Core.Application.DTOs;
using TransportesDosGuri.Core.Application.ServiceContracts;

namespace TransportesDosGuri.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class TripController : CustomControllerBase
    {
        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        /// <summary>
        /// Endpoint to GET ALL data stored in the Trip Table
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAll = await _tripService.GetAllAsync();

            return Ok(getAll);
        }

        /// <summary>
        /// Endpoint to GET BY ID a specific row stored in the Trip Table
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var getById = await _tripService.GetByIdAsync(id);

            return Ok(getById);
        }

        /// <summary>
        /// Endpoint to CREATE a row of information in the Trip Table
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(TripDTO trip)
        {
            var create = await _tripService.CreateAsync(trip);

            return Ok("Data Saved");
        }

        /// <summary>
        /// Endpoint to UPDATE BY ID a row stored in the Trip Table
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, TripDTO trip)
        {
            var update = await _tripService.UpdateAsync(id, trip);

            return Ok("Data Updated");
        }

        /// <summary>
        /// Endpoint to DELETE BY ID a row stored in the Trip Table
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var delete = await _tripService.DeleteAsync(id);

            return Ok("Data Deleted");
        }
    }
}
