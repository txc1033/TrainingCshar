using System.Collections.Generic;

namespace CsharLibrary.Examples
{
    public interface IOrchestrator
    {
        List<string> ExecuteAction(string action);

        List<string> GetActions();
    }
}