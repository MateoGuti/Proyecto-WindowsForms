using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEmpresarial2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text=="Mateo" && txtContraseña.Text=="1234")
            {
                Home V1 = new Home();
                V1.Show();
                txtUsuario.Text = "";
                txtContraseña.Text = "";
            }
            else
            {
                MessageBox.Show("No puede ingresar");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
