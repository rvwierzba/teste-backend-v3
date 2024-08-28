
namespace TheatricalPlayersRefactoringKata.PriceCalculators;
public class HistoryPriceCalculator : IPriceCalculator
{
    private readonly TragedyPriceCalculator _tragedyCalculator = new TragedyPriceCalculator();
    private readonly ComedyPriceCalculator _comedyCalculator = new ComedyPriceCalculator();

    public decimal CalculatePrice(int audience, int numberOfLines)
    {
        return _tragedyCalculator.CalculatePrice(audience, numberOfLines)
             + _comedyCalculator.CalculatePrice(audience, numberOfLines);
    }

    public int CalculateCredits(int audience)
    {
        return _tragedyCalculator.CalculateCredits(audience)
             + _comedyCalculator.CalculateCredits(audience);
    }
}
