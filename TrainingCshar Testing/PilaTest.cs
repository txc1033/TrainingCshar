using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingCshar.Collections;

namespace TrainingCshar_Testing
{
    [TestClass]
    public class PilaTest
    {
        [TestMethod]
        public void CastStackReturnObject()
        {
            PersonaPila pila = new PersonaPila("queso");
            Stack<PersonaPila> personaPila = new Stack<PersonaPila>();
            personaPila.Push(pila);
            personaPila.Push(new PersonaPila("queque", 15));
            Stack<PersonaPila> copia = pila.ClonarPila(personaPila);
            Stack<PersonaPila> copia2 = personaPila.Peek().ClonarPila(personaPila);
            Assert.AreEqual(copia.Peek(), copia2.Peek());
        }
    }
}
