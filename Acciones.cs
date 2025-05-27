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
                string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Autos_Importacion.xlsx");

                if (!File.Exists(rutaArchivo))
                    return false;

                using (var workbook = new XLWorkbook(rutaArchivo))
                {
                    var hoja = workbook.Worksheets.First();
                    var filas = hoja.RowsUsed().Skip(1);

                    foreach (var fila in filas)
                    {
                        Auto auto = new Auto()
                        {
                            Id = int.Parse(fila.Cell(1).GetValue<string>()),
                            Marca = fila.Cell(2).GetValue<string>(),
                            Modelo = fila.Cell(3).GetValue<string>(),
                            Anio = int.Parse(fila.Cell(4).GetValue<string>()),
                            Color = fila.Cell(5).GetValue<string>(),
                            Precio = double.Parse(fila.Cell(6).GetValue<string>()),
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
    }
}
