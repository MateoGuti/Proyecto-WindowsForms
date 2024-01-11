using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEmpresarial2
{
    public partial class AggProductos : Form
    {
        public AggProductos()
        {
            InitializeComponent();
            consultaP();
        }
        //Cadena de conexion
        static string conexionstringP = "server=DESKTOP-97AN3JJ; database=PuntoVenta; integrated security = true";
        SqlConnection conexionP = new SqlConnection(conexionstringP);
        public void consultaP()
        {
            string consulta = "SELECT * FROM PRODUCTO";
            SqlCommand comandoP = new SqlCommand(consulta, conexionP);
            SqlDataAdapter data = new SqlDataAdapter(comandoP);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            DataGridP.DataSource = tabla;
        }
        private void BtnConsultarP_Click(object sender, EventArgs e)
        {
            try
            {
                conexionP.Open();
                if (txtConsultaP.Text == "")
                {
                    string consulta = "SELECT * FROM PRODUCTO";
                    SqlCommand comandoPr = new SqlCommand(consulta, conexionP);
                    SqlDataAdapter data = new SqlDataAdapter(comandoPr);
                    DataTable tabla = new DataTable();
                    data.Fill(tabla);
                    DataGridP.DataSource = tabla;

                }
                else
                {
                    string consulta = "SELECT * FROM PRODUCTO WHERE id= '" + txtConsultaP.Text + "'";
                    SqlCommand comando = new SqlCommand(consulta, conexionP);
                    SqlDataAdapter data = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    data.Fill(tabla);
                    DataGridP.DataSource = tabla;
                }
                txtConsultaP.Text = "";
                conexionP.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("No se encontro el numero de id");
                txtConsultaP.Text = "";
            }
        }
        //Controla que en el textbox solo se puedan ingresar numeros
        private void txtConsultaP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar>=32 && e.KeyChar<=47 || e.KeyChar>= 58 && e.KeyChar<=255)
            {
                MessageBox.Show("Solo se pueden ingresar numeros");
                e.Handled = true;
                return;
            }
        }

        private void btnFuncionalidadesP_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.Show();
        }
    }
}
