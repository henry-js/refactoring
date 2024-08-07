using System.Text.Json;
using TheatreCompany;

JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };

var playsJson = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plays.json"));
var plays = JsonSerializer.Deserialize<PlayDict>(playsJson, options) ?? [];

var invoicesJson = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "invoices.json"));
var invoices = JsonSerializer.Deserialize<List<Invoice>>(invoicesJson, options) ?? [];

var generate = new StatementGenerator();
foreach (var invoice in invoices)
{
    var statement = generate.Statement(invoice, plays);

    Console.WriteLine(statement);
}
