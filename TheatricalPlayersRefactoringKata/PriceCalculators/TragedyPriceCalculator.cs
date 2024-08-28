using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata.PriceCalculators;
public class TragedyPriceCalculator : IPriceCalculator
{
    public decimal CalculatePrice(int audience, int numberOfLines)
    {
        decimal basePrice = Math.Clamp(numberOfLines, 1000, 4000) / 10;
        if (audience > 30)
        {
            basePrice += (audience - 30) * 10m;
        }
        return basePrice;
    }

    public int CalculateCredits(int audience)
    {
        return Math.Max(audience - 30, 0);
    }
}

