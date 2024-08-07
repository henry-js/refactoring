using System.Text.Json;
using TheatreCompany;

namespace tests;

public class TheatreCompanyTests
{
    private readonly string _plays = """
{
    "hamlet": {
        "name": "Hamlet",
        "type": "tragedy"
    },
    "as-like": {
        "name": "As You Like It",
        "type": "comedy"
    },
    "othello": {
        "name": "Othello",
        "type": "tragedy"
    }
}
""";

    private readonly string _invoices
    JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive = true };

    public TheatreCompanyTests()
    {

        _invoices = JsonSerializer.Deserialize<List<Invoice>>(invoicesJson, _options) ?? [];

    }
    [Fact]
    public void Test1()
    {

    }
}
