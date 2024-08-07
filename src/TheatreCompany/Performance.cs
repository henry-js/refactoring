namespace TheatreCompany;
public record Performance
{
    public required string PlayId { get; set; }
    public required int Audience { get; set; }
}
