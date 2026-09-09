using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TransportesDosGuri.Core.Application.DTOs;
using TransportesDosGuri.Core.Application.ServiceContracts;

namespace TransportesDosGuri.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class PurchaseController : CustomControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        /// <summary>
        /// Endpoint to GET ALL data stored in the Purchase Table
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAll = await _purchaseService.GetAllAsync();

            return Ok(getAll);
        }

        /// <summary>
        /// Endpoint to GET BY ID a specific row stored in the Purchase Table
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var getById = await _purchaseService.GetByIdAsync(id);

            return Ok(getById);
        }

        /// <summary>
        /// Endpoint to CREATE a row of information in the Purchase Table
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(PurchaseDTO purchase)
        {
            var create = await _purchaseService.CreateAsync(purchase);

            return Ok("Data Saved");
        }

        /// <summary>
        /// Endpoint to UPDATE BY ID a row stored in the Purchase Table
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, PurchaseDTO purchase)
        {
            var update = await _purchaseService.UpdateAsync(id, purchase);

            return Ok("Data Updated");
        }

        /// <summary>
        /// Endpoint to DELETE BY ID a row stored in the Purchase Table
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var delete = await _purchaseService.DeleteAsync(id);

            return Ok("Data Deleted");
        }
    }
}
