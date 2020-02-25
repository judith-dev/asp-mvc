using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Negocio
{
    public class Empleado
    {

        Data.Connection Connection;
        DataSet oDataSet;

        public List<Entidades.Empleado> ObtenerEmpleados()
        {
            try
            {

                Connection = new Data.Connection();
                oDataSet = new DataSet();
                SqlParameter[] oParameters = new SqlParameter[2];
                oParameters[0] = new SqlParameter("@Accion", 1);
                oDataSet = Connection.EjecuteQueryDs("spEmpleados", oParameters);
                Entidades.Empleado oEmpleado = new Entidades.Empleado();

                List<Entidades.Empleado>  Lista = AutoMapper.Mapper.Map<IDataReader, List<Entidades.Empleado>>(oDataSet.Tables[0].CreateDataReader());


                return Lista;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool GuardaEmpleado(Entidades.Empleado pEmpleado)
        {
            try
            {
                Connection = new Data.Connection();
                oDataSet = new DataSet();
                SqlParameter[] oParameters = new SqlParameter[6];
                oParameters[0] = new SqlParameter("@Accion", 2);
                oParameters[1] = new SqlParameter("@Nombre", pEmpleado.Nombre);
                oParameters[2] = new SqlParameter("@Puesto", pEmpleado.Puesto);
                oParameters[3] = new SqlParameter("@Oficina", pEmpleado.Oficina);
                oParameters[4] = new SqlParameter("@Edad", pEmpleado.Edad);
                oParameters[5] = new SqlParameter("@Salario", pEmpleado.Salario);
                bool result = Connection.EjecuteQuery("spEmpleados", oParameters);

                return result;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool EliminarEmpleado(Entidades.Empleado pEmpleado)
        {
            try
            {
                Connection = new Data.Connection();
                oDataSet = new DataSet();
                SqlParameter[] oParameters = new SqlParameter[2];
                oParameters[0] = new SqlParameter("@Accion", 3);
                oParameters[1] = new SqlParameter("@EmpleadoId", pEmpleado.EmpleadoId);
                bool result = Connection.EjecuteQuery("spEmpleados", oParameters);

                return result;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool ModificarEmpleado(Entidades.Empleado pEmpleado)
        {
            try
            {
                Connection = new Data.Connection();
                oDataSet = new DataSet();
                SqlParameter[] oParameters = new SqlParameter[7];
                oParameters[0] = new SqlParameter("@Accion", 4);
                oParameters[1] = new SqlParameter("@Nombre", pEmpleado.Nombre);
                oParameters[2] = new SqlParameter("@Puesto", pEmpleado.Puesto);
                oParameters[3] = new SqlParameter("@Oficina", pEmpleado.Oficina);
                oParameters[4] = new SqlParameter("@Edad", pEmpleado.Edad);
                oParameters[5] = new SqlParameter("@Salario", pEmpleado.Salario);
                oParameters[6] = new SqlParameter("@EmpleadoId", pEmpleado.EmpleadoId);
                bool result = Connection.EjecuteQuery("spEmpleados", oParameters);

                return result;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
