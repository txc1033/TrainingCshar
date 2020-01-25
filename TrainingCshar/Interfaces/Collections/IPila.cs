using System.Collections.Generic;

namespace TrainingCshar.Collections
{
    internal interface IPila
    {
        void Agregar(Persona persona);

        void Agregar(Stack<Persona> stack);

        string Cantidad();

        Stack<Persona> Clonar();

        void Eliminar(bool todos);

        List<string> Imprimir();
    }
}