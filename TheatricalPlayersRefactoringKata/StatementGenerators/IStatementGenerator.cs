using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata.StatementGenerators;
public interface IStatementGenerator
{
    string GenerateStatement(IEnumerable<Performance> performances);
}
