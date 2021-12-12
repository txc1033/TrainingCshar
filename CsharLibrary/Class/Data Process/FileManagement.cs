using CsharLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace CsharLibrary.Data_Process
{
    internal class FileManagement : IFileManagement
    {
        private const string _directory = @"C:\TrainingDb\";
        private CultureInfo currentCulture = CultureInfo.CurrentCulture;
        private const string formatDate = "dd-MM-yyyy HH:mm:ss";
        private IPerson person;

        public FileManagement()
        {
            person = new Person();
        }

        public string GetRootDirectory()
        {
            if (!Directory.Exists(_directory))
            {
                Directory.CreateDirectory(_directory);
            }

            return _directory;
        }

        public string GetFormatDate()
        {
            return formatDate;
        }

        public string GetDefaultFileName()
        {
            string fileName = $"DGPersona_{DateTime.Now.ToString(formatDate, currentCulture)}.csv";
            return fileName.Replace(" ", "_").Replace(":", "");
        }

        public List<Person> LoadCsv(string fileName)
        {
            return _LoadCsv(fileName);
        }

        public string SaveCsv(List<Person> personas, string directory)
        {
            return _SaveCsv(personas, directory);
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
                            var getPerson = person.TextToPerson(rows);

                            if (getPerson is null)
                                continue;
                            csvPersons.Add(getPerson);
                        }
                    }
                    catch
                    {
                        return csvPersons;
                    }
                }
            }

            return csvPersons;
        }
        private string _SaveCsv(List<Person> people, string fileName)
        {
                if (people.Count > 1)
                {
                    var text = person.PersonToText(people);

                    File.WriteAllText(fileName, text.ToString());

                    LoadTextEditor(fileName);
                }
                else if(!string.IsNullOrEmpty(fileName))
                {
                    return $"La tabla no tiene suficientes datos para exportarse";
                }
            return $"la tabla fue guardada correctamente en el archivo: {Path.GetFileNameWithoutExtension(fileName)}";
        }

        private void LoadTextEditor(string fileName)
        {
            try
            {
                Process.Start("notepad++.exe", fileName);
            }
            catch (Exception)
            {
                Process.Start("notepad.exe", fileName);
            }
        }
    }
}