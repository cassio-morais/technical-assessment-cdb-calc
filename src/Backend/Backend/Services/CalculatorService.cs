using Backend.Api.Core.Dtos;
using Backend.Api.Core.Services;

namespace Backend.Api.Services
{
    public class CalculatorService(ITaxService taxService) : ICalculatorService
    {
        private const decimal Tb = 1.08m; // 108%
        private const decimal Cdi = 0.009m; // 0.9%
        private const decimal BaseMultiplier = 1;
        private const decimal CdbMultiplier = (BaseMultiplier + (Tb * Cdi)); // [1 + (cdi * tb)]
        private readonly ITaxService _taxService = taxService;

        public CdbCalculationResponse CalculateCdbInvestment(decimal initialAmount, int months)
        {
            if (initialAmount <= 0 || months <= 0)
                throw new ArgumentException("Values cannot be less than or equal 0");

            var grossIncome = CalculateInvestment(initialAmount, months);

            var profit = grossIncome - initialAmount;
            var taxAmount = _taxService.GetTheCdbTaxAmount(profit, months);

            var netIncome = grossIncome - taxAmount;

            return new CdbCalculationResponse(
                Math.Round(grossIncome, 2),
                Math.Round(netIncome, 2));
        }

        private static decimal CalculateInvestment(decimal initialAmount, int months)
        {
            decimal grossIncome = initialAmount;
            for (int i = 0; i < months; i++)
            {
                grossIncome = grossIncome * CdbMultiplier;
            }

            return grossIncome;
        }
    }
}
