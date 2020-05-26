using System.Collections.Generic;

namespace TrainingCshar.Collections
{
    internal interface IPila
    {
        void Agregar(PersonaPila persona);

        void Agregar(Stack<PersonaPila> stack);

        string Cantidad();

        Stack<PersonaPila> Clonar();

        void Eliminar(bool todos);

        List<string> Imprimir();
    }
}