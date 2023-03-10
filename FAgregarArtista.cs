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
    public partial class FAgregarArtista : Form
    {
        string fNombre;
        int fAño;
        CEstilo fEstilo = null;
        CPaís fPaís = null;

        public FAgregarArtista()
        {
            InitializeComponent();
          
        }

        private void FAgregarArtista_Load(object sender, EventArgs e)
        {
            cbPaíses.DataSource = null;
            cbPaíses.DataSource = CPaís.Países;
            cbPaíses.DisplayMember = "Nombre";
            cbSelEstilo.DataSource = null;
            cbSelEstilo.DataSource = CEstilo.Estilos;
            cbSelEstilo.DisplayMember = "Nombre";

        }

        private void Actualizar(ICalificable aActualizar)
        {
            if (aActualizar is CPaís) 
            {
                cbPaíses.DataSource = null;
                cbPaíses.DataSource = CPaís.Países;
                cbPaíses.DisplayMember = "Nombre";
            }
            if (aActualizar is CEstilo)
            {
                cbSelEstilo.DataSource = null;
                cbSelEstilo.DataSource = CEstilo.Estilos;
                cbSelEstilo.DisplayMember = "Nombre";
            }
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            fNombre = tbNombre.Text;
            try { fAño = Convert.ToInt16(tbAño.Text); }
            catch { MessageBox.Show("Introduce un año válido."); tbAño.Text = ""; return; }
            fEstilo = (CEstilo)cbSelEstilo.SelectedItem;
            fPaís = (CPaís)cbPaíses.SelectedItem;

            tbNombre.Text = "";
            tbAño.Text = "";

            CArtista nuevoArtista = new CArtista(fNombre, fAño, fPaís, fEstilo);
            this.Close();
        }

        private void butAgrPaís_Click(object sender, EventArgs e)
        {
            if (cbPaíses.Text != "")
            {
                List<CPaís> lList = CPaís.Países; 
                
                bool bRepetido = false;
                foreach (CPaís pais in lList)  
                {
                    if (pais.Nombre.ToLower() == cbPaíses.Text.ToLower()) { bRepetido = true; break; }
                }

                if (!bRepetido)
                {
                    CPaís oPaís = new CPaís(cbPaíses.Text);
                    MessageBox.Show($"{cbPaíses.Text} agregado a Países.");
                    Actualizar(oPaís);

                    int cantidad = CPaís.Países.Count;
                    cbPaíses.SelectedIndex = cantidad - 1; 
                }
                else { MessageBox.Show($"Ese país ya existe."); cbPaíses.Text = ""; }

            }
            else 
            {
                MessageBox.Show("Nombre inválido."); 
            }
        }

        private void butAgrEstilo_Click(object sender, EventArgs e)
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
                    Actualizar(oEstilo);

                    int cantidad = CEstilo.Estilos.Count;
                    cbSelEstilo.SelectedIndex = cantidad - 1;
                }
                else { MessageBox.Show($"Ese estilo ya existe."); cbSelEstilo.Text = ""; }
            }
            else
            {
                MessageBox.Show("Nombre inválido o ya existente.");
            }

        }
    }
}
