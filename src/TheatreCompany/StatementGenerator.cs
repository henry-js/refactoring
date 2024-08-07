namespace TheatreCompany;

public class StatementGenerator
{
    public string Statement(Invoice invoice, PlayDict plays)
    {
        int totalAmount = 0;
        int volumeCredits = 0;
        string result = $"Statement for {invoice.Customer}\n";

        foreach (var perf in invoice.Performances)
        {
            Play play = plays[perf.PlayId];
            var thisAmount = 0;

            switch (play.Type)
            {
                case "tragedy":
                    thisAmount = 40_000;
                    if (perf.Audience > 30)
                    {
                        thisAmount += 1000 * (perf.Audience - 30);
                    }
                    break;
                case "comedy":
                    thisAmount = 30_000;
                    if (perf.Audience > 20)
                    {
                        thisAmount += 10_000 + 500 * (perf.Audience - 20);
                    }
                    thisAmount += 300 * perf.Audience;
                    break;
                default:
                    throw new Exception($"Unknown type: {play.Type}");
            }

            volumeCredits += Math.Max(perf.Audience - 30, 0);

            if ("comedy" == play.Type) volumeCredits += (int)Math.Floor((double)perf.Audience / 5);

            result += $"\t {play.Name}: {thisAmount / 100:C} ({perf.Audience} seats)\n";
            totalAmount += thisAmount;
        }

        result += $"Amount owed is {totalAmount / 100:C}\n";
        result += $"You earned {volumeCredits} credits\n";

        return result;
    }

}
