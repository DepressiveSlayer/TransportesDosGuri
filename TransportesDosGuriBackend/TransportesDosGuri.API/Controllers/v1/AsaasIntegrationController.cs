using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TransportesDosGuri.Core.Application.DTOs;
using TransportesDosGuri.Core.Application.ServiceContracts;

namespace TransportesDosGuri.API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class AsaasIntegrationController : CustomControllerBase
    {
        private readonly IAsaasIntegrationService _asaasIntegrationsService;

        public AsaasIntegrationController(IAsaasIntegrationService asaasIntegrationsService)
        {
            _asaasIntegrationsService = asaasIntegrationsService;
        }

        /// <summary>
        /// Endpoint to GET ALL data stored in the AsaasIntegration Table
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAll = await _asaasIntegrationsService.GetAllAsync();

            return Ok(getAll);
        }

        /// <summary>
        /// Endpoint to GET BY ID a specific row stored in the AsaasIntegration Table
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var getById = await _asaasIntegrationsService.GetByIdAsync(id);

            return Ok(getById);
        }

        /// <summary>
        /// Endpoint to CREATE a row of information in the AsaasIntegration Table
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(AsaasIntegrationDTO asaasIntegration)
        {
            var create = await _asaasIntegrationsService.CreateAsync(asaasIntegration);

            return Ok("Data Saved");
        }

        /// <summary>
        /// Endpoint to UPDATE BY ID a row stored in the AsaasIntegration Table
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, AsaasIntegrationDTO asaasIntegration)
        {
            var update = await _asaasIntegrationsService.UpdateAsync(id, asaasIntegration);

            return Ok("Data Updated");
        }

        /// <summary>
        /// Endpoint to DELETE BY ID a row stored in the AsaasIntegration Table
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var delete = await _asaasIntegrationsService.DeleteAsync(id);

            return Ok("Data Deleted");
        }
    }
}
