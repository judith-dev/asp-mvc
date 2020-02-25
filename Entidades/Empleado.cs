using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public string Oficina { get; set; }
        public int Edad { get; set; }
        public decimal Salario { get; set; }

    }
}
