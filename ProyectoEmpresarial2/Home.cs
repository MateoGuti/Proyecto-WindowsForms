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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        //Hace que los botones se abran o se escondan. 
        private void BtnReportes_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = true;
        }

        private void BtnRventas_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible=false;
        }

        private void BtnRcompras_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = false;
        }

        private void BtnRpagos_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = false;
        }
        //Se llama otra ventana de windows form dentro del contenedor, la condicion If sirve para ecargar las ventanas. se crea 
        //un metodo para ser llamado por el boton. 
        private void AbrirenUser(object FormUser)
        {
            if (this.Panelcontenedor.Controls.Count>0)
            {
                this.Panelcontenedor.Controls.RemoveAt(0);
            }
            Form fh = FormUser as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Panelcontenedor.Controls.Add(fh);
            this.Panelcontenedor.Tag=fh;
            fh.Show();
        }
        //Se llama el metodo para abrir el otro form
        private void BtnClientes_Click(object sender, EventArgs e)
        {
            AbrirenUser(new Clientes());
        }

        private void AbrirenProductos(object Formproduc)
        {
            if (this.Panelcontenedor.Controls.Count > 0)
            {
                this.Panelcontenedor.Controls.RemoveAt(0);
            }
            Form productos = Formproduc as Form;
            productos.TopLevel = false;
            productos.Dock = DockStyle.Fill;
            this.Panelcontenedor.Controls.Add(productos);
            this.Panelcontenedor.Tag = productos;
            productos.Show();
        }
        private void BtnProductos_Click(object sender, EventArgs e)
        {
            AbrirenProductos(new AggProductos());
        }
    }

    
}
