using Backend.Api.Core.Dtos;

namespace Backend.Api.Core.Services
{
    public interface ICalculatorService
    {
        CdbCalculationResponse CalculateCdbInvestment(decimal initialAmount, int months);
    }
}
