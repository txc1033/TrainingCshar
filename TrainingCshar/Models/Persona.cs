using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCshar.Models
{
    class Persona
    {
        public int per_idPersona { get; set; }
        public string per_nombre { get; set; }
        public string per_apellido { get; set; }
        public int per_edad { get; set; }
        public int per_rut { get; set; }
        public string per_dv { get; set; }
        public DateTime per_fechaNacimiento { get; set; }
    }
}
