using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordinario_ofi_wen
{
    internal interface IAcciones
    {
        List<Auto> Consultar();

        bool Agregar(int Id, string Marca, string Modelo, int Anio, string Color, double Precio, string Estado);
        bool Eliminar(int Id);
        bool Actualizar(int Id, string Marca, string Modelo, int Anio, string Color, double Precio, string Estado);
        bool ExportarExcel();
        bool ImportarExcel();


        //YA SALIOOOOOOOOOOOOOOO
    }
}
