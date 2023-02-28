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
    public partial class FAgregarDisco : Form
    {
        CArtista fArtista = null;
        string fNombre;
        int fAño;
        CEstilo fEstilo = null;
        


        public FAgregarDisco()
        {
            InitializeComponent();
            //cbSelEstilo.DataSource = CEstilo.Estilos;
        }

        private void FAgregarDisco_Load(object sender, EventArgs e)
        {
            this.Text = $"Agregar tema para {fArtista.Nombre}";
        }
        public void ObtenerArtista(CArtista _artista)
        {
            fArtista = _artista;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            fNombre = tbNombre.Text;
            try { fAño = Convert.ToInt16(tbAño.Text); }
            catch { MessageBox.Show("Introduce un año válido."); tbAño.Text = ""; return; }
            fEstilo = (CEstilo)cbSelEstilo.SelectedItem;
            

            tbNombre.Text = "";
            tbAño.Text = "";

            CDisco nuevoDisco = new CDisco(fNombre, fAño, new CEstilo("Power Metal"), fArtista);
            CDisco.Discos.Add(nuevoDisco);
            fArtista.ObtenerDisco(nuevoDisco);
           
            this.Close();
        }
    }
}
