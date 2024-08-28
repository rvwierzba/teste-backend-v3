using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TheatricalPlayersRefactoringKata.StatementGenerators
{
    public class XmlStatementGenerator : IStatementGenerator
    {
        public string GenerateStatement(Invoice invoice, Dictionary<string, Play> plays)
        {
            var invoiceElement = new XElement("invoice",
                new XElement("customer", invoice.Customer),
                new XElement("performances",
                    from performance in invoice.Performances
                    let play = plays[performance.PlayId]
                    let amount = CalculateAmountForPerformance(performance, play)
                    select new XElement("performance",
                        new XElement("playID", performance.PlayId),
                        new XElement("playName", play.Name),
                        new XElement("audience", performance.Audience),
                        new XElement("amount", amount.ToString("F2")),
                        new XElement("credits", CalculateCreditsForPerformance(performance, play))
                    )
                ),
                new XElement("totalAmount", invoice.Performances.Sum(p => CalculateAmountForPerformance(p, plays[p.PlayId])).ToString("F2")),
                new XElement("totalCredits", invoice.Performances.Sum(p => CalculateCreditsForPerformance(p, plays[p.PlayId])))
            );

            return invoiceElement.ToString();
        }

        internal string GenerateStatement(List<Performance> performances)
        {
            throw new NotImplementedException();
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
