using System.Collections.Generic;

namespace TrainingCshar.Examples
{
    public interface IOrquestador
    {
        List<string> EjecutaAccion(string accion);
        List<string> GetAcciones();
    }
}