using appPractica.Winform.Entities;
using appPractica.Winform.Interfaces;
using appPractica.Winform.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appPractica.Winform.DAL
{
    class DALPersona : IDALPersona
    {
        public void Actualizar(Persona persona)
        {
            using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "P_Actualizar";
                comando.Parameters.AddWithValue("@Id", persona.Id);
                comando.Parameters.AddWithValue("@Nombre", persona.Nombre);
                comando.Parameters.AddWithValue("@Apellido1", persona.Apellido1);
                comando.Parameters.AddWithValue("@Apellido2", persona.Apellido2);
                comando.Parameters.AddWithValue("@Telefono", persona.Telefono);
                comando.Parameters.AddWithValue("@CorreoElectronico", persona.CorreoElectronico);
                comando.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                comando.Parameters.AddWithValue("@Edad", persona.Edad);
                comando.Parameters.AddWithValue("@Genero", persona.Genero);
                comando.Parameters.AddWithValue("@Direccion", persona.Direccion);
                comando.Parameters.AddWithValue("@Nacionalidad", persona.Nacionalidad);

                db.ExecuteNonQuery(comando);
            }
        }

        public void Eliminar(string Id)
        {
            using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "P_Eliminar";
                comando.Parameters.AddWithValue("@Id", Id);

                db.ExecuteNonQuery(comando);
            }
        }

        public void Insertar(Persona persona)
        {
            using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "P_Insertar";
                comando.Parameters.AddWithValue("@Id", persona.Id);
                comando.Parameters.AddWithValue("@Nombre", persona.Nombre);
                comando.Parameters.AddWithValue("@Apellido1", persona.Apellido1);
                comando.Parameters.AddWithValue("@Apellido2", persona.Apellido2);
                comando.Parameters.AddWithValue("@Telefono", persona.Telefono);
                comando.Parameters.AddWithValue("@CorreoElectronico", persona.CorreoElectronico);
                comando.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                comando.Parameters.AddWithValue("@Edad", persona.Edad);
                comando.Parameters.AddWithValue("@Genero", persona.Genero);
                comando.Parameters.AddWithValue("@Direccion", persona.Direccion);
                comando.Parameters.AddWithValue("@Nacionalidad", persona.Nacionalidad);

                db.ExecuteNonQuery(comando);
            }
        }

        public Persona SeleccionarPorId(string Id)
        {
     
            Persona opersona = new Persona();

            using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "P_SelectporId";
                comando.Parameters.AddWithValue("@Id",Id);

                DataSet ds = db.ExecuteDataSet(comando);

                if(ds.Tables[0].Rows.Count >0)
                {

                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        opersona.Id = dr["Id"].ToString();
                        opersona.Nombre = dr["Nombre"].ToString();
                        opersona.Apellido1 = dr["Apellido1"].ToString();
                        opersona.Apellido2 = dr["Apellido2"].ToString();
                        opersona.Telefono = (int)dr["Telefono"];
                        opersona.CorreoElectronico = dr["CorreoElectronico"].ToString();
                        opersona.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                        opersona.Edad= (int)dr["Edad"];
                        opersona.Genero = dr["Genero"].ToString();
                        opersona.Direccion = dr["Direccion"].ToString();
                        opersona.Nacionalidad = dr["Nacionalidad"].ToString();
                    }

                    return opersona;

                }else
                {
                    return null;
                }

            }



        }

        public List<Persona> SeleccionarTodo()
        {
            List<Persona> listpersonas = new List<Persona>();

            using (IDataBase db = FactoryDataBase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();

                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "P_Select";

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Persona opersona = new Persona();

                    opersona.Id = dr["Id"].ToString();
                    opersona.Nombre = dr["Nombre"].ToString();
                    opersona.Apellido1 = dr["Apellido1"].ToString();
                    opersona.Apellido2 = dr["Apellido2"].ToString();
                    opersona.Telefono = (int)dr["Telefono"];
                    opersona.CorreoElectronico = dr["CorreoElectronico"].ToString();
                    opersona.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                    opersona.Edad = (int)dr["Edad"];
                    opersona.Genero = dr["Genero"].ToString();
                    opersona.Direccion = dr["Direccion"].ToString();
                    opersona.Nacionalidad = dr["Nacionalidad"].ToString();

                    listpersonas.Add(opersona);
                }

                return listpersonas;


            }



        }
    }
}
