namespace webapi.Dtos;

public class ProcessPaymentRequest
{
    public string Title { get; set; }

    public int Quantity { get; set; }

    public string CurrencyId { get; set; }

    public decimal UnitPrice { get; set; }
}
