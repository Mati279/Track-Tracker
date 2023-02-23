using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Track_Tracker
{
    public partial class FAgregarPerfil : Form
    {
        Form1 oForm1;
        public FAgregarPerfil()
        {
            InitializeComponent();
        }

        private void FAgregarPerfil_Load(object sender, EventArgs e)
        {
            oForm1 = SingletonData.Instance.sForm1;
        }

       
        private void butAgregarPerfil_Click(object sender, EventArgs e)
        {
            if (textboxNombrePerfil.Text != "")
            {
                oForm1.AgregarPerfilNuevo(textboxNombrePerfil.Text);
                textboxNombrePerfil.Text = "";
                this.Close();
            }
            else 
            {
                MessageBox.Show("Nombre Inválido");
            }
        }
    }
}
