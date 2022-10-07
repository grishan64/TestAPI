namespace TestAPI.DTO;

public record Currency
{
    public string SpecificDate {get; init;}
    public List<Models.Currency> Currencies {get; init;}
}