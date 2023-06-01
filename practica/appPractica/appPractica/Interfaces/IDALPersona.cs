using appPractica.Winform.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appPractica.Winform.Interfaces
{
     interface IDALPersona
    {
        void Insertar(Persona persona);

        void Actualizar(Persona persona);
      
        Persona SeleccionarPorId(string Id);

        List<Persona> SeleccionarTodo();

        void Eliminar(string Id);
    }
}
