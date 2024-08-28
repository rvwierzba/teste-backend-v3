using System;


namespace TheatricalPlayersRefactoringKata.PriceCalculators;
public class ComedyPriceCalculator : IPriceCalculator
{
    public decimal CalculatePrice(int audience, int numberOfLines)
    {
        decimal basePrice = Math.Clamp(numberOfLines, 1000, 4000) / 10;
        basePrice += audience * 3m;

        if (audience > 20)
        {
            basePrice += 100m + (audience - 20) * 5m;
        }
        return basePrice;
    }

    public int CalculateCredits(int audience)
    {
        int credits = Math.Max(audience - 30, 0);
        credits += audience / 5;  // Bônus para comédia
        return credits;
    }
}

