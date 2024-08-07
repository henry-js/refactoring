namespace TheatreCompany;

public record Invoice
{
    public required string Customer { get; set; }
    public required List<Performance> Performances { get; set; }

}
