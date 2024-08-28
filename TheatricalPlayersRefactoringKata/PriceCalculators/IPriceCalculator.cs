
namespace TheatricalPlayersRefactoringKata.PriceCalculators;
public interface IPriceCalculator
{
    decimal CalculatePrice(int audience, int numberOfLines);
    int CalculateCredits(int audience);
}
