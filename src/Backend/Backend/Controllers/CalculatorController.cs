using Backend.Api.Core.Dtos;
using Backend.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Backend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController(ICalculatorService calculatorService) : ControllerBase
    {
        private readonly ICalculatorService _calculatorService = calculatorService;

        /// <summary>
        /// Calculate CDB investment income
        /// </summary>
        /// <param name="dto"> Initial investment and months </param>
        /// <returns></returns>
        [HttpPost("cdb")]
        [ProducesResponseType(typeof(CdbCalculationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody][Required] CdbCalculationRequest dto)
        {
            if (dto.InitialAmount <= 0 || dto.Months <= 0)
                return BadRequest(new ProblemDetails() { Title = "Values cannot be less than or equal 0" });

            var response = _calculatorService.CalculateCdbInvestment(dto.InitialAmount, dto.Months);

            return Ok(response);
        }
    }

    public record CdbCalculationRequest(
        decimal InitialAmount,
        int Months);
}
