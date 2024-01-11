using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace ProyectoEmpresarial2
{
    public partial class AggClientes : Form
    {

        static string conexionstrin = "server=DESKTOP-97AN3JJ; database=PuntoVenta; integrated security = true";
        readonly SqlConnection conexion = new SqlConnection(conexionstrin);
        Clientes clientes = new Clientes();
        public AggClientes()
        {
            InitializeComponent();
        }
        //Abre la ventana de archivos y toma la ruta del archivo que se elija. 
        private void BtnExplorar_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Busca tu archivo";
            openFileDialog1.ShowDialog();

            if (File.Exists(openFileDialog1.FileName))
            {
                txtDoc.Text = openFileDialog1.FileName;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "INSERT INTO USUARIO VALUES ('"+txtNombre.Text+"','"+txtApellido.Text+"','"+txtDui.Text+"','"+txtNit.Text+"','"+txtCorreo.Text+"','"+txtTelefono.Text+"','"+txtDoc.Text+"')";
            SqlCommand comando = new SqlCommand(consulta,conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Los datos del cliente fueron agregados con exito");
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDui.Text =null;
            txtNit.Text = null;
            txtCorreo.Text = "";
            txtTelefono.Text = null;
            conexion.Close();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text=="" || txtApellido.Text=="" || txtDui.Text=="" || txtNit.Text=="" ||txtCorreo.Text=="" ||txtTelefono.Text==""||txtDoc.Text=="")
            {
                MessageBox.Show("No se ingreso ningun cambio");
            }
            else
            {
                conexion.Open();
                string actualizar = "UPDATE USUARIO SET nombre='"+txtNombre.Text+"',apellido='"+txtApellido.Text+"'"+
                    ",dui='"+txtDui.Text+"',nit='"+txtNit.Text+"',correo='"+txtCorreo.Text+"',telefono='"+txtTelefono.Text+"'"+"" +
                    ",doc='"+txtDoc.Text+"' where id='"+txtBuscar.Text+"';";
                SqlCommand comandoA = new SqlCommand(actualizar, conexion);
                comandoA.ExecuteNonQuery();
                MessageBox.Show("Se actualizo el registro");
                conexion.Close();
            }
            
        }
        //Lee el contenido que hay en la base de datos y lo imprime en los textbox
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                if (txtBuscar.Text == "")
                {
                    MessageBox.Show("El buscador se encuentra vacio");
                }
                else
                {
                    
                    string buscar = "SELECT * FROM USUARIO WHERE id = " + txtBuscar.Text + "";
                    SqlCommand comando2 = new SqlCommand(buscar, conexion);
                    SqlDataReader leer = comando2.ExecuteReader();
                    if (leer.Read() == true)
                    {
                        txtNombre.Text = leer["nombre"].ToString();
                        txtApellido.Text = leer["apellido"].ToString();
                        txtDui.Text = leer["dui"].ToString();
                        txtNit.Text = leer["nit"].ToString();
                        txtCorreo.Text = leer["correo"].ToString();
                        txtTelefono.Text = leer["telefono"].ToString();
                        txtDoc.Text = leer["doc"].ToString();
                    }
                    txtBuscar.Text = "";
                    
                }
                conexion.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No se encontro el numero de id ingresado");
                txtBuscar.Text = "";
            }
            
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string Eliminar = "DELETE FROM USUARIO WHERE id='"+txtBuscar.Text+"';";
            SqlCommand comando = new SqlCommand(Eliminar, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Se ha eliminado el registro");
            conexion.Close();
        }
        //No permite el ingreso de letras en txtDui tipo int
        private void txtDui_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo se pueden ingresar numeros");
                e.Handled = true;
                return;
            }
        }
        //No permite el ingreso de letras en txtNit tipo int
        private void txtNit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo se pueden ingresar numeros");
                e.Handled = true;
                return;
            }
        }
        //No permite el ingreso de letras en txtTelefono tipo int
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo se pueden ingresar numeros");
                e.Handled = true;
                return;
            }
        }
        //No permite el ingreso de letras en txtBuscar tipo int
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo se pueden ingresar numeros");
                e.Handled = true;
                return;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
