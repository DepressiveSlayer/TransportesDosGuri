using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TransportesDosGuri.Core.Application.DTOs;
using TransportesDosGuri.Core.Application.ServiceContracts;

namespace TransportesDosGuri.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class UserRequestController : CustomControllerBase
    {
        private readonly IUserRequestService _userRequestService;

        public UserRequestController(IUserRequestService userRequestService)
        {
            _userRequestService = userRequestService;
        }

        /// <summary>
        /// Endpoint to GET ALL data stored in the UserRequest Table
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAll = await _userRequestService.GetAllAsync();

            return Ok(getAll);
        }

        /// <summary>
        /// Endpoint to GET BY ID a specific row stored in the UserRequest Table
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var getById = await _userRequestService.GetByIdAsync(id);

            return Ok(getById);
        }

        /// <summary>
        /// Endpoint to CREATE a row of information in the UserRequest Table
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserRequestDTO userRequest)
        {
            var create = await _userRequestService.CreateAsync(userRequest);

            return Ok("Data Saved");
        }

        /// <summary>
        /// Endpoint to UPDATE BY ID a row stored in the UserRequest Table
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, UserRequestDTO userRequest)
        {
            var update = await _userRequestService.UpdateAsync(id, userRequest);

            return Ok("Data Updated");
        }

        /// <summary>
        /// Endpoint to DELETE BY ID a row stored in the UserRequest Table
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var delete = await _userRequestService.DeleteAsync(id);

            return Ok("Data Deleted");
        }

        [HttpPost("with-payment")]
        public async Task<IActionResult> CreateWithPaymentAsync([FromBody] UserRequestDTO userRequest)
        {
            try
            {
                var result = await _userRequestService.CreateWithPaymentAsync(userRequest);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
