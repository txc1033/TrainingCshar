using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsharLibrary.Class.Data_Process;
using CsharLibrary.Encoder;
using CsharLibrary;
using System;

namespace TrainingCshar_Testing.Class.DataProcess
{
    [TestClass]
    public class ManagementFunctions
    {
        Service servicio = new Service();
        SqlAccess sql = new SqlAccess();


        [TestMethod]
        public void GetDbData()
        {
            try
            {
                Management managent = new Management(servicio.csharContainer);
                Encode.Process(sql.db, false);
                var result = managent.LoadDB();
                Assert.IsNotNull(result);
                foreach (var item in result)
                {
                    string table = string.Format("| {0} | {1} | {2} | {3} | {4} | {5} | {6} |" +
                                               "\n------------------------------------------",
                        item.per_idPersona,item.per_nombre, item.per_apellido, item.per_edad
                       ,item.per_rut, item.per_dv, item.per_fechaNacimiento);
                    Console.WriteLine(table);
                }
                
            }
            catch(Exception error)
            {
                string message = string.Format("Se genero un problema con la prueba: \n{0}"
                                               ,error.Message);
                throw new AssertFailedException(message);
            }
        }
        [TestMethod]
        public void SaveData()
        {
            Management managent = new Management(servicio.csharContainer);
            Encode.Process(sql.db, false);
            var data = managent.LoadDB();
            var result = managent.SaveCsv(data, "Prueba");
            StringAssert.Contains(result, "guardada correctamente");
            Console.WriteLine(result);
        }

        [TestMethod]
        public void GetDirectory()
        {
            Management managent = new Management(servicio.csharContainer);
            var result = managent.GetDefaultFileName();
            Assert.IsNotNull(result);
            result = managent.GetRootDirectory();
            StringAssert.Contains(result, "TrainingDb");
            Console.WriteLine(result);
        }
    }
}
