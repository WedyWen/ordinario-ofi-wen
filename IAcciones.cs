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

        void Agregar();
        void Eliminar();
        void Actualizar();
        void ExportarExcel();
        void ImportarExcel();


    }
}
