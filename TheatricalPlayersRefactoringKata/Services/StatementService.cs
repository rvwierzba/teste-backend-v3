using System.Collections.Generic;
using System;
using TheatricalPlayersRefactoringKata.PriceCalculators;
using TheatricalPlayersRefactoringKata.StatementGenerators;

namespace TheatricalPlayersRefactoringKata.Services
{
    public class StatementService
    {
        private readonly Dictionary<string, IPriceCalculator> _calculators;
        private readonly Dictionary<string, IStatementGenerator> _statementGenerators;

        public StatementService()
        {
            _calculators = new Dictionary<string, IPriceCalculator>
            {
                { "tragedy", new TragedyPriceCalculator() },
                { "comedy", new ComedyPriceCalculator() },
                { "history", new HistoryPriceCalculator() } 
            };

            _statementGenerators = new Dictionary<string, IStatementGenerator>
            {
                { "text", new TextStatementGenerator() },
                { "xml", new XmlStatementGenerator() }
            };
        }

        public string GenerateStatement(string format, IEnumerable<Performance> performances)
        {
            if (!_statementGenerators.ContainsKey(format))
                throw new ArgumentException("Unsupported format");

            return _statementGenerators[format].GenerateStatement(performances);
        }

        public decimal CalculateTotalPrice(string genre, int audience, int numberOfLines)
        {
            if (!_calculators.ContainsKey(genre))
                throw new ArgumentException("Unsupported genre");

            return _calculators[genre].CalculatePrice(audience, numberOfLines);
        }

        public int CalculateTotalCredits(string genre, int audience)
        {
            if (!_calculators.ContainsKey(genre))
                throw new ArgumentException("Unsupported genre");

            return _calculators[genre].CalculateCredits(audience);
        }
    }
}
