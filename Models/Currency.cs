namespace TestAPI.Models;

public abstract class Currency
{
    public string CurrencyName { get; set; }
    public decimal Value { get; set; }

    protected decimal RandomDecimal (double minValue, double maxValue)
    {
    return Convert.ToDecimal(Random.Shared.NextDouble() * (maxValue - minValue) + minValue);
    }
}

public class USD : Currency
{
    public USD ()
    {
        CurrencyName = "USD";
        Value = Math.Round(RandomDecimal(100.0,200.0),2);
    }
}

public class EUR : Currency
{
    public EUR ()
    {
        CurrencyName = "EUR";
        Value = Math.Round(RandomDecimal(200.0,300.0),2);
    }
}

public class GBP : Currency
{
    public GBP ()
    {
        CurrencyName = "GBP";
        Value = Math.Round(RandomDecimal(300.0,400.0),2);
    }
}