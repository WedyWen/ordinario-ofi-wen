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
    }
}
