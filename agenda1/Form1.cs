using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace agenda1
{
    public partial class Form1 : Form
    {
        Usuario[] usuarios = new Usuario[100];

        List <Usuario> listUsuarios = new List<Usuario>();

        int contador = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btGuardarRegistro_Click(object sender, EventArgs e)
        {

            usuarios[contador] = new Usuario();

            usuarios[contador].nombre = tbNombre.Text;
            usuarios[contador].email = tbEmail.Text;
            usuarios[contador].tel = tbTel.Text;

            Usuario usr_temp = new Usuario(tbNombre.Text, tbEmail.Text, tbTel.Text);
            listUsuarios.Add(usr_temp);

            MessageBox.Show(listUsuarios.Count().ToString());

            MessageBox.Show("Registro guardado");
            tbTel.Text = "";
            tbEmail.Text = "";
            tbNombre.Clear();
            ++contador;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cbUsuarios.Items.Clear();
            for (int i = 0; i < contador; i++)
            {
                cbUsuarios.Items.Add(usuarios[i].nombre + " - " + usuarios[i].email);
            }
            foreach(Usuario user in listUsuarios)
            {

            }
        }

        private void cbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = cbUsuarios.SelectedItem;
            MessageBox.Show(selectedItem.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BaseDatos datos = new BaseDatos();
            datos.select("SELECT * FROM usuarios");
            dgvUsuarios.DataSource = datos.dt;
          
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            BaseDatos datos = new BaseDatos();
            datos.select("SELECT * FROM usuarios WHERE nombre like '%" + tbBuscar.Text + "%' OR email like '%" + tbBuscar.Text + "%' OR tel like '%" + tbBuscar.Text + "%'");
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = datos.dt;
        }
    }
}
