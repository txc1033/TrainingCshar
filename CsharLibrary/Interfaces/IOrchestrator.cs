using System.Collections.Generic;

namespace CsharLibrary.Examples
{
    public interface IOrchestrator
    {
        List<string> ExecuteAction(string accion);
        List<string> GetAcciones();
    }
}