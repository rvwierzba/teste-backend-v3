using System;
using System.Collections.Generic;
using System.Text;

namespace TheatricalPlayersRefactoringKata.StatementGenerators
{
    public class TextStatementGenerator : IStatementGenerator
    {
        public string GenerateStatement(Invoice invoice, Dictionary<string, Play> plays)
        {
            var result = new StringBuilder();
            decimal totalAmount = 0m;
            int totalCredits = 0;

            result.AppendLine($"Statement for {invoice.Customer}");

            foreach (var performance in invoice.Performances)
            {
                var play = plays[performance.PlayId];
                decimal thisAmount = CalculateAmountForPerformance(performance, play);

                // Adiciona as informações da performance ao extrato
                result.AppendLine($"{play.Name}: {thisAmount:C} ({performance.Audience} seats)");

                totalAmount += thisAmount;
                totalCredits += CalculateCreditsForPerformance(performance, play);
            }

            // Adiciona o total e os créditos ao final do extrato
            result.AppendLine($"Amount owed is {totalAmount:C}");
            result.AppendLine($"You earned {totalCredits} credits");

            return result.ToString();
        }

        private decimal CalculateAmountForPerformance(Performance performance, Play play)
        {
            decimal thisAmount = 0m;
            switch (play.Type)
            {
                case "tragedy":
                    thisAmount = 40000;
                    if (performance.Audience > 30)
                    {
                        thisAmount += 1000 * (performance.Audience - 30);
                    }
                    break;
                case "comedy":
                    thisAmount = 30000;
                    if (performance.Audience > 20)
                    {
                        thisAmount += 10000 + 500 * (performance.Audience - 20);
                    }
                    thisAmount += 300 * performance.Audience;
                    break;
                    // Adicione outros tipos de gênero aqui
            }

            return thisAmount / 100; // Convertendo centavos para unidades monetárias
        }

        private int CalculateCreditsForPerformance(Performance performance, Play play)
        {
            int credits = Math.Max(performance.Audience - 30, 0);
            if (play.Type == "comedy")
            {
                credits += (int)Math.Floor((decimal)performance.Audience / 5);
            }
            return credits;
        }
    }
}
