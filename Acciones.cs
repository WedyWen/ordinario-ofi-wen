using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ordinario_ofi_wen
{
    internal class Acciones : IAcciones
    {
        Correo correo = new Correo();
        List<Auto> listaAuto = new List<Auto>();
        Auto Auto = new Auto ();

        public bool Agregar(int Id, string Marca, string Modelo, int Anio, string Color, double Precio, string Estado)
        {
            try
            {
                listaAuto.Add(new Auto(Auto.Id = Id, Auto.Marca = Marca, Auto.Modelo = Modelo, Auto.Anio = Anio, Auto.Color = Color, Auto.Precio = Precio, Auto.Estado = Estado));
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
            return listaAuto;
        }

        public bool Actualizar(int Id, string Marca, string Modelo, int Anio, string Color, double Precio, string Estado)
        {
            try
            {
                var objetoActualizar = listaAuto.Find(x => x.Id == Id);
                if (objetoActualizar != null)
                {
                    objetoActualizar.Marca = Marca;
                    objetoActualizar.Modelo = Modelo;
                    objetoActualizar.Anio = Anio;
                    objetoActualizar.Color = Color;
                    objetoActualizar.Precio = Precio;
                    objetoActualizar.Estado = Estado;
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

        public bool ImportarExcel()
        {
            try
            {
                string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Autos_Importacion.xlsx");

                if (!File.Exists(rutaArchivo))
                    return false;

                using (var workbook = new XLWorkbook(rutaArchivo))
                {
                    var hoja = workbook.Worksheets.First();
                    var filas = hoja.RowsUsed().Skip(1);

                    listaAuto.Clear();

                    foreach (var fila in filas)
                    {
                        Auto auto = new Auto()
                        {
                            Id = fila.Cell(1).GetValue<int>(),
                            Marca = fila.Cell(2).GetValue<string>(),
                            Modelo = fila.Cell(3).GetValue<string>(),
                            Anio = fila.Cell(4).GetValue<int>(),
                            Color = fila.Cell(5).GetValue<string>(),
                            Precio = fila.Cell(6).GetValue<double>(),
                            Estado = fila.Cell(7).GetValue<string>()
                        };

                        listaAuto.Add(auto);
                    }
                }

                return true;
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
                if (listaAuto.Count == 0)
                    return false;

                string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Autos_Exportados.xlsx");

                using (var workbook = new XLWorkbook())
                {
                    var hoja = workbook.Worksheets.Add("Autos");

                    hoja.Cell(1, 1).Value = "Id";
                    hoja.Cell(1, 2).Value = "Marca";
                    hoja.Cell(1, 3).Value = "Modelo";
                    hoja.Cell(1, 4).Value = "Año";
                    hoja.Cell(1, 5).Value = "Color";
                    hoja.Cell(1, 6).Value = "Precio";
                    hoja.Cell(1, 7).Value = "Estado";

                    int fila = 2;
                    foreach (var auto in listaAuto)
                    {
                        hoja.Cell(fila, 1).Value = auto.Id;
                        hoja.Cell(fila, 2).Value = auto.Marca;
                        hoja.Cell(fila, 3).Value = auto.Modelo;
                        hoja.Cell(fila, 4).Value = auto.Anio;
                        hoja.Cell(fila, 5).Value = auto.Color;
                        hoja.Cell(fila, 6).Value = auto.Precio;
                        hoja.Cell(fila, 7).Value = auto.Estado;
                        fila++;
                    }

                    workbook.SaveAs(rutaArchivo);
                }

                return true;
            }
            catch (Exception ex)
            {
                correo.EnviarCorreo(ex.ToString());
                return false;
            }

        }

        public int ContarAutos()
         {
            return listaAuto.Count;
         }

        public double SumaPrecios()
        {
            double suma = 0;
            foreach (var auto in listaAuto)
            {
                suma += auto.Precio;
            }
            return suma;
        }

    }
}
