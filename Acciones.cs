using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ordinario_ofi_wen
{
    internal class Acciones:IAcciones
    {
        Correo correo = new Correo();
        List<Auto> listaAuto = new List<Auto>();
        Auto A = new Auto();

        bool IAcciones.Agregar(int Id, string Marca, string Modelo, int Anio, string Color, double Precio, string Estado)
        {
            try
            {
                listaAuto.Add(new Auto(A.Id = Id, A.Marca = Marca, A.Modelo = Modelo, A.Anio = Anio, A.Color = Color, A.Precio = Precio, A.Estado = Estado));
                return true;
            }
            catch (Exception ex)
            {
                correo.EnviarCorreo(ex.ToString());
                return false;
            }
        }

        public List<Auto> Consultar()
        {
            try
            {
                return listaAuto;
            }
            catch (Exception ex)
            {
                correo.EnviarCorreo(ex.ToString());
                throw;
            }
        }

        public bool Actualizar(int Id, string Marca, string Modelo, int Anio, string Color, double Precio, string Estado)
        {
            try
            {
                var objetotoAcctualizar = listaAuto.Find(x => x.Id == Id);
                if (objetotoAcctualizar != null)
                {
                    objetotoAcctualizar.Id = Id;
                    objetotoAcctualizar.Marca = Marca;
                    objetotoAcctualizar.Modelo = Modelo;
                    objetotoAcctualizar.Anio = Anio;
                    objetotoAcctualizar.Precio = Precio;
                    objetotoAcctualizar.Estado = Estado;
                    return true;
                }
                 return true;
            }
            catch (Exception ex)
            {
                correo.EnviarCorreo(ex.ToString());
                return false;
            }
        }

        

        public bool Eliminar(int Id)
        {
            try
            {
                var objetoEliminar = listaAuto.Find(x => x.Id == Id);
                if (objetoEliminar != null)
                {
                    listaAuto.Remove(objetoEliminar);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                correo.EnviarCorreo(ex.ToString());
                return false;
            }
        }

        public bool ExportarExcel()
        {
            try
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Autos");

                // Encabezados
                worksheet.Cell(1, 1).Value = "Id";
                worksheet.Cell(1, 2).Value = "Marca";
                worksheet.Cell(1, 3).Value = "Modelo";
                worksheet.Cell(1, 4).Value = "Año";
                worksheet.Cell(1, 5).Value = "Color";
                worksheet.Cell(1, 6).Value = "Precio";
                worksheet.Cell(1, 7).Value = "Estado";

                // Datos
                for (int i = 0; i < listaAuto.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = listaAuto[i].Id;
                    worksheet.Cell(i + 2, 2).Value = listaAuto[i].Marca;
                    worksheet.Cell(i + 2, 3).Value = listaAuto[i].Modelo;
                    worksheet.Cell(i + 2, 4).Value = listaAuto[i].Anio;
                    worksheet.Cell(i + 2, 5).Value = listaAuto[i].Color;
                    worksheet.Cell(i + 2, 6).Value = listaAuto[i].Precio;
                    worksheet.Cell(i + 2, 7).Value = listaAuto[i].Estado;
                }

                // Guardar en escritorio
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = System.IO.Path.Combine(desktopPath, "Autos.xlsx");
                workbook.SaveAs(filePath);

                return true;
            }
            catch (Exception ex)
            {
                correo.EnviarCorreo(ex.ToString());
                return false;
            }
        }

        public bool ImportarExcel()
        {

            try
            {
                // Ruta del archivo en escritorio
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = System.IO.Path.Combine(desktopPath, "Autos.xlsx");

                if (!System.IO.File.Exists(filePath))
                {
                    return false; // No se encontró el archivo
                }

                // Limpiar la lista antes de cargar
                listaAuto.Clear();

                // Abrir el archivo Excel
                var workbook = new XLWorkbook(filePath);
                var worksheet = workbook.Worksheet("Autos");

                // Leer las filas (empezamos en 2 para saltar encabezados)
                int fila = 2;
                while (!worksheet.Cell(fila, 1).IsEmpty())
                {
                    Auto auto = new Auto();
                    auto.Id = Convert.ToInt32(worksheet.Cell(fila, 1).Value);
                    auto.Marca = worksheet.Cell(fila, 2).Value.ToString();
                    auto.Modelo = worksheet.Cell(fila, 3).Value.ToString();
                    auto.Anio = Convert.ToInt32(worksheet.Cell(fila, 4).Value);
                    auto.Color = worksheet.Cell(fila, 5).Value.ToString();
                    auto.Precio = Convert.ToDouble(worksheet.Cell(fila, 6).Value);
                    auto.Estado = worksheet.Cell(fila, 7).Value.ToString();

                    listaAuto.Add(auto);
                    fila++;
                }

                return true;
            }
            catch (Exception ex)
            {
                correo.EnviarCorreo(ex.ToString());
                return false;
            }
        }

        
    }
}
