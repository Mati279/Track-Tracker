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
            Actualizar();
        }

        private void FAgregarDisco_Load(object sender, EventArgs e)
        {
            this.Text = $"Agregar tema para {fArtista.Nombre}";
           
            Actualizar();
        }

        private void Actualizar()
        {
            cbSelEstilo.DataSource = null;
            cbSelEstilo.DataSource = CEstilo.Estilos;
            cbSelEstilo.DisplayMember = "Nombre";
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
            if (cbSelEstilo.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un Estilo.");

<<<<<<< Updated upstream
            CDisco nuevoDisco = new CDisco(fNombre, fAño, new CEstilo("Power Metal"), fArtista);
            fArtista.ObtenerDisco(nuevoDisco);

            this.Close();
=======
            }
            else
            {
                CDisco nuevoDisco = new CDisco(fNombre, fAño, fEstilo, fArtista);
                CDisco.Discos.Add(nuevoDisco);
                fArtista.ObtenerDisco(nuevoDisco);
                this.Close();
            }
>>>>>>> Stashed changes
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbSelEstilo.Text != "")
            {
                List<CEstilo> lList = CEstilo.Estilos;
                bool bRepetido = false;
                foreach (CEstilo estilo in lList)
                {
                    if (estilo.Nombre.ToLower() == cbSelEstilo.Text.ToLower()) { bRepetido = true; break; }
                }


                if (!bRepetido)
                {
                    CEstilo oEstilo = new CEstilo(cbSelEstilo.Text);
                    MessageBox.Show($"{cbSelEstilo.Text} agregado a Estilo.");
                    Actualizar();

                    int cantidad = CEstilo.Estilos.Count;
                    cbSelEstilo.SelectedIndex = cantidad - 1;
                }
                else { MessageBox.Show($"Ese estilo ya existe."); cbSelEstilo.Text = ""; }
            }
            else
            {
                MessageBox.Show("Nombre inválido.");
            }
        }

<<<<<<< Updated upstream
        private void button2_Click_1(object sender, EventArgs e)
        {

            if (cbSelEstilo.Text != "")
            {


                bool bRepetido = false;
                foreach (CEstilo estilo in CEstilo.Estilos)
                {
                    if (estilo.Nombre.ToLower() == cbSelEstilo.Text.ToLower()) { bRepetido = true; break; }
                }

                if (!bRepetido)
                {
                    CEstilo oEstilo = new CEstilo(cbSelEstilo.Text);
                    MessageBox.Show($"{cbSelEstilo.Text} agregado a Estilos.");
                    int cantidad = CEstilo.Estilos.Count;
                    Actualizar();
                    cbSelEstilo.SelectedIndex = cantidad - 1;
                }
                else { MessageBox.Show($"Ese estilo ya existe."); cbSelEstilo.Text = ""; }

            }
            else
            {
                MessageBox.Show("Nombre inválido.");
            }
        }

=======
      

        
>>>>>>> Stashed changes
    }
}
