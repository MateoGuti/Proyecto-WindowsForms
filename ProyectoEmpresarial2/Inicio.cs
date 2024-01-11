using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEmpresarial2
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
            consulta();
        }
        //Cadena de conexion
        static string conexionstring = "server=DESKTOP-97AN3JJ; database=PuntoVenta; integrated security = true";
        SqlConnection conexion = new SqlConnection(conexionstring);
        public void consulta()
        {
            string consulta = "SELECT * FROM USUARIO";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            DataGrid.DataSource = tabla;
        }
        //Consulta los datos del datagrid
        private void BtnConsultar_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                conexion.Open();
                if (txtConsulta.Text == "")
                {
                    
                    string consulta = "SELECT * FROM USUARIO";
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    SqlDataAdapter data = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    data.Fill(tabla);
                    DataGrid.DataSource = tabla;

                }
                else
                {
                    string consulta = "SELECT * FROM USUARIO WHERE id= '" + txtConsulta.Text + "'";
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    SqlDataAdapter data = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    data.Fill(tabla);
                    DataGrid.DataSource = tabla;
                }
                txtConsulta.Text = "";
                conexion.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("No se encontraron resultados");
                txtConsulta.Text = "";
            }
            
            
        }

        private void BtnFunciones_Click(object sender, EventArgs e)
        {
            AggClientes aggClientes = new AggClientes();
            aggClientes.Show();
        }
        //Se toma la ruta y busca el archivo con el fin de abrirlo. 
        private void btnArchivo_Click(object sender, EventArgs e)
        {
            if (txtArchivo.Text=="")
            {
                MessageBox.Show("No se ingreso ninguna ruta");
            }
            else
            {
                Process proceso = new Process();
                proceso.StartInfo.FileName = @"" + txtArchivo.Text;
                proceso.Start();
            }
        }
        //Se crea el metodo para tomar la base de datos y expòrtarla a un excel 
        public void exportaraexcel(DataGridView tabla)
        {

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int IndiceColumna = 0;

            foreach (DataGridViewColumn col in tabla.Columns)
            {

                IndiceColumna++;

                excel.Cells[1, IndiceColumna] = col.Name;

            }

            int IndeceFila = 0;

            foreach (DataGridViewRow row in tabla.Rows)
            {

                IndeceFila++;

                IndiceColumna = 0;

                foreach (DataGridViewColumn col in tabla.Columns)
                {

                    IndiceColumna++;

                    excel.Cells[IndeceFila + 1, IndiceColumna] = row.Cells[col.Name].Value;

                }

            }

            excel.Visible = true;


        }
        //Llama el metodo que se creo para exportar el excel y recibe un objeto de tipo DataGrid 
        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportaraexcel(DataGrid);
        }
        //No permite el ingreso de letras en txtConsulta tipo int
        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo se pueden ingresar numeros");
                e.Handled = true;
                return;
            }
        }
    }
}
