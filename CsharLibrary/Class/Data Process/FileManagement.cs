using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using CsharLibrary.Models;

namespace CsharLibrary.Data_Process
{
    class FileManagement : IFileManagement
    {
        private const string _directory = @"C:\TrainingDb\";
        private CultureInfo currentCulture = CultureInfo.CurrentCulture;

        public FileManagement()
        {
        }

        public string GetRootDirectory()
        {
            if (!Directory.Exists(_directory))
            {
                Directory.CreateDirectory(_directory);
            }

            return _directory;
        }

        public string GetDefaultFileName()
        {
            return $"DGPersona_{DateTime.Now.ToString("dd-MM-yyyy_HHmm", currentCulture)}.csv";
        }

        public List<Person> LoadCsv(string fileName)
        {
            return _LoadCsv(fileName);
        }

        public string SaveCsv(List<Person> personas,string directory)
        {
            return _SaveCsv(personas,directory);
        }

        private List<Person> _LoadCsv(string fileName)
        {
            List<Person> csvPersons = new List<Person>();

            if (!string.IsNullOrEmpty(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    try
                    {
                        while (!sr.EndOfStream)
                        {
                            string[] rows = sr.ReadLine().Split(',');
                            if (!rows[0].ToString(currentCulture).Equals("ID", StringComparison.CurrentCulture) && !string.IsNullOrEmpty(rows[0].ToString(currentCulture)))
                            {
                                Person person = new Person()
                                {
                                    per_idPersona = int.Parse(rows[0], currentCulture),
                                    per_nombre = rows[1],
                                    per_apellido = rows[2],
                                    per_edad = int.Parse(rows[3], currentCulture),
                                    per_rut = int.Parse(rows[4], currentCulture),
                                    per_dv = rows[5],
                                    per_fechaNacimiento = DateTime.Parse(rows[6], currentCulture)
                                };
                                csvPersons.Add(person);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        return csvPersons;
                    }
                }
            }

            return csvPersons;
        }

        private string _SaveCsv(List<Person> persons,string fileName)
        {
            try
            {
                if (persons.Count > 1)
                { 
                    StringBuilder text = new StringBuilder(2655, 28000);
                    string columns = "ID,Nombre,Apellidos"
                                   + ",Edad,Rut,Digito Verificador"
                                   + ",Fecha Nacimiento";

                    text.AppendLine(columns); 
                    int count = 1;
                    foreach (var person in persons)
                    {
                        string row = $"{count}"
                                   + $",{person.per_nombre}"
                                   + $",{person.per_apellido}"
                                   + $",{person.per_edad}"
                                   + $",{person.per_rut}"
                                   + $",{person.per_dv}" 
                                   + $",{person.per_fechaNacimiento}";
                        if (!string.IsNullOrEmpty(row))
                            text.AppendLine(row);

                        count++;
                    }

                    File.WriteAllText(fileName, text.ToString());

                    ///<summary>
                    /// Una vez guardado lo abrimos con un editor de texto para
                    /// verificar que contenga la informacion
                    /// </summary>
                    try
                    {
                        Process.Start("notepad++.exe", fileName);
                    }
                    catch (Exception)
                    {
                        Process.Start("notepad.exe", fileName);
                    }
                }
                else
                {
                    return $"La tabla no tiene suficientes datos para exportarse";
                }
            }
            catch (Exception e)
            {
                return $"El formato que se intenta exportar no es valido\n{e.TargetSite}";
            }
            return string.Empty;
        }
    }
}