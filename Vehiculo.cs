using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordinario_ofi_wen
{
    internal class Vehiculo
    {
        public Vehiculo(int id, string marca, string modelo, int anio, string color)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
            Color = color;
        }
        public Vehiculo() { }

        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; }
    }
}
