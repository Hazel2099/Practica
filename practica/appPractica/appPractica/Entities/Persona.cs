using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appPractica.Winform.Entities
{
     class Persona
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }

        public int Telefono { get; set; }

        public string CorreoElectronico { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Genero { get; set; }

        public string Direccion { get; set; }

        public string Nacionalidad { get; set; }




    }
}
