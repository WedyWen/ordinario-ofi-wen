namespace ordinario_ofi_wen
{
    public partial class Loggin : Form
    {
        Usuarios usuarios = new Usuarios();
        public Loggin()
        {
            InitializeComponent();
        }

        private void btnINGRESAR_Click(object sender, EventArgs e)
        {
            string user = txbUSUARIO.Text;
            string password = txbCONTRASENIA.Text;

            var lista = usuarios.ObtenerUsuario();
            var validar = lista.FirstOrDefault(u => u.Usuario == user && u.Contrasenia == password);
            if (validar != null)
            {
                this.Hide();
                Inicio inicio = new Inicio();
                inicio.Show();
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}
