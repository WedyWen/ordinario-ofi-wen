using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ordinario_ofi_wen
{
    public partial class Inicio : Form
    {
        Acciones acciones = new Acciones();
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnAGREGAR_Click(object sender, EventArgs e)
        {
            if (acciones.Agregar(Convert.ToInt32(txbID.Text), txbMARCA.Text, txbMODELO.Text, Convert.ToInt32(txbANIO.Text), txbCOLOR.Text, Convert.ToDouble(txbPRECIO.Text), txbESTADO.Text))
                MessageBox.Show("Agregado con exito");
            else MessageBox.Show("Error al exportar, intenta de nuevo");
        }

        private void btnEXP_Click(object sender, EventArgs e)
        {
            if (acciones.ExportarExcel())
                MessageBox.Show("Exportado con exito");
            else
                MessageBox.Show("Error al exportar, intenta de nuevo");
        }

        private void btnIMP_Click(object sender, EventArgs e)
        {
            if (acciones.ImportarExcel())
            {
                MessageBox.Show("Importado con exito");
            }
            else
            {
                MessageBox.Show("Error al importar, intenta de nuevo");
            }
        }

        private void btnMOSTRAR_Click(object sender, EventArgs e)
        {
            dgDATOS.DataSource = null;
            dgDATOS.DataSource = acciones.Consultar();
        }

        private void btnELIMINAR_Click(object sender, EventArgs e)
        {
            if (acciones.Eliminar(Convert.ToInt32(txbELIMINAR.Text)))
                MessageBox.Show("Eliminada con exito");
            else
                MessageBox.Show("Error al eliminar, intentalo de nuevo");
        }

        private void btnACTUALIZAR_Click(object sender, EventArgs e)
        {
            if (acciones.Actualizar(Convert.ToInt32(txbACTUALIZARID.Text), txbMARCA.Text, txbMODELO.Text, Convert.ToInt32(txbANIO.Text), txbCOLOR.Text, Convert.ToDouble(txbPRECIO.Text), txbESTADO.Text))
                MessageBox.Show("Actualizado con exito");
            else MessageBox.Show("Fallo al actualizar");
        }

        private void btnCONTARELEM_Click(object sender, EventArgs e)
        {
            int cantidad = acciones.ContarAutos();
            MessageBox.Show($"Tienes: {cantidad} elementos hasta ahora");
        }

        private void btnSUMA_Click(object sender, EventArgs e)
        {
            double suma = acciones.SumaPrecios();
            MessageBox.Show($"La suma total de precios de los autos es: {suma}");
        }
    }
}
