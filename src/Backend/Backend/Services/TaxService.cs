using Backend.Api.Core.Services;

namespace Backend.Api.Services
{
    public class TaxService : ITaxService
    {
        public decimal GetTheCdbTaxAmount(decimal value, int months)
        {
            decimal tax;

            if (months <= 6)
            {
                tax = 0.225m; // 22.5%
                return value * tax;
            }

            if (months <= 12)
            {
                tax = 0.20m; // 20%
                return value * tax;
            }

            if (months <= 24)
            {
                tax = 0.175m; // 17.5%
                return value * tax;
            }

            tax = 0.15m; // 15%
            return value * tax;
        }
    }
}
