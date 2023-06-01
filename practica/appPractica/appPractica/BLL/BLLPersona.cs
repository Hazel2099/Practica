using appPractica.Winform.Entities;
using appPractica.Winform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appPractica.Winform.BLL
{
    class BLLPersona : IBLLPersona
    {
        public void Eliminar(string Id)
        {
            DAL.DALPersona db = new DAL.DALPersona();

            db.Eliminar(Id);
        }

        public void Guardar(Persona persona)
        {
            DAL.DALPersona db = new DAL.DALPersona();

            if(db.SeleccionarPorId(persona.Id) == null)
            {
                db.Insertar(persona);
            }
            else
            {
                db.Actualizar(persona);
            }

        }

        public Persona SeleccionarPorId(string Id)
        {
            DAL.DALPersona db = new DAL.DALPersona();
            return db.SeleccionarPorId(Id);
        }

        public List<Persona> SeleccionarTodo()
        {
            DAL.DALPersona db = new DAL.DALPersona();
            return db.SeleccionarTodo();
        }
    }
}
