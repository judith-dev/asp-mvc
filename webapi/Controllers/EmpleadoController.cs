using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace webapi.Controllers
{
    [RoutePrefix("api/Empleado")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmpleadoController : ApiController
    {
        [HttpPost]
        [Route("ObtenerEmpleados")]
        public IHttpActionResult ObtenerEmpleados()
        {
            Negocio.Empleado Empleado = new Negocio.Empleado();
            var resultado = Empleado.ObtenerEmpleados();
            return Ok(resultado);
        }

        [HttpPost]
        [Route("Insert")]
        public IHttpActionResult Insert(Entidades.Empleado paramEmpleados)
        {
            Negocio.Empleado Empleado = new Negocio.Empleado();
            var resultado = Empleado.GuardaEmpleado(paramEmpleados);
            return Ok(resultado);
        }
        [HttpPost]
        [Route("Eliminar")]
        public IHttpActionResult Eliminar(Entidades.Empleado paramEmpleados)
        {
            Negocio.Empleado Empleado = new Negocio.Empleado();
            var resultado = Empleado.EliminarEmpleado(paramEmpleados);
            return Ok(resultado);
        }
        [HttpPost]
        [Route("Modificar")]
        public IHttpActionResult Modificar(Entidades.Empleado paramEmpleados)
        {
            Negocio.Empleado Empleado = new Negocio.Empleado();
            var resultado = Empleado.ModificarEmpleado(paramEmpleados);
            return Ok(resultado);
        }
    }
}
