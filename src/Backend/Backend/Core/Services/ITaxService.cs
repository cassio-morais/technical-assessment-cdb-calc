namespace Backend.Api.Core.Services
{
    public interface ITaxService
    {
        decimal GetTheCdbTaxAmount(decimal value, int months);
    }
}
