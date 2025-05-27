using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ordinario_ofi_wen
{
    internal class Vehiculo
    {

        public Vehiculo(double precio, string estado)
        {
            Precio = precio;
            Estado = estado;
        }

        public double Precio { get; set; }
        public string Estado { get; set; }

        public Vehiculo() { }
    }
}
