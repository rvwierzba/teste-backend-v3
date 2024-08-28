using NUnit.Framework;
using System.Collections.Generic;
using TheatricalPlayersRefactoringKata.StatementGenerators;
using TheatricalPlayersRefactoringKata;

[TestFixture]
public class StatementGeneratorTests
{
    [Test]
    public void TextStatementGenerator_GeneratesCorrectStatement()
    {
        var generator = new TextStatementGenerator();
        var performances = new List<Performance>
        {
            new Performance { PlayId = "hamlet", Audience = 55 },
            new Performance { PlayId = "as-like", Audience = 35 }
        };

        var plays = new Dictionary<string, Play>
        {
            { "hamlet", new Play { Name = "Hamlet", Type = "tragedy", Lines = 1500 } },
            { "as-like", new Play { Name = "As You Like It", Type = "comedy", Lines = 1000 } }
        };

        var invoice = new Invoice { Customer = "BigCo", Performances = performances };

        string result = generator.GenerateStatement(invoice, plays);

        Assert.That(result, Does.Contain("Statement for BigCo"));
        Assert.That(result, Does.Contain("Hamlet"));
        Assert.That(result, Does.Contain("As You Like It"));
        Assert.That(result, Does.Contain("Amount owed is"));
        Assert.That(result, Does.Contain("You earned"));
    }

    [Test]
    public void XmlStatementGenerator_GeneratesCorrectXml()
    {
        var generator = new XmlStatementGenerator();
        var performances = new List<Performance>
        {
            new Performance { PlayId = "hamlet", Audience = 55 },
            new Performance { PlayId = "as-like", Audience = 35 }
        };

        var plays = new Dictionary<string, Play>
        {
            { "hamlet", new Play { Name = "Hamlet", Type = "tragedy", Lines = 1500 } },
            { "as-like", new Play { Name = "As You Like It", Type = "comedy", Lines = 1000 } }
        };

        var invoice = new Invoice { Customer = "BigCo", Performances = performances };

        string result = generator.GenerateStatement(invoice, plays);

        Assert.That(result, Does.Contain("<invoice>"));
        Assert.That(result, Does.Contain("<customer>BigCo</customer>"));
        Assert.That(result, Does.Contain("<playName>Hamlet</playName>"));
    }
}
