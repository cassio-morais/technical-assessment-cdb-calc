namespace Backend.Api.Core.Dtos
{
    public record CdbCalculationRequest(
        decimal InitialAmount,
        int Months);
}
