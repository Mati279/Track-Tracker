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
        CEstilo fEstilo;
        CPaís fPaís;

        public FAgregarArtista()
        {
            InitializeComponent();
            Actualizar(fEstilo);
            Actualizar(fPaís);
        }

        private void FAgregarArtista_Load(object sender, EventArgs e)
        {

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
                cbEstilo.DataSource = null;
                cbEstilo.DataSource = CEstilo.Estilos;
                cbEstilo.DisplayMember = "Nombre";
            }

        }

        private void butOK_Click(object sender, EventArgs e)
        {
            fNombre = tbNombre.Text;
            try { fAño = Convert.ToInt16(tbAño.Text); }
            catch { MessageBox.Show("Introduce un año válido."); return; }
            fEstilo = (CEstilo)cbEstilo.SelectedItem;
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
                foreach (CPaís objeto in lList)
                {
                    if (objeto.Nombre == cbPaíses.Text) { bRepetido = true;}
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
                MessageBox.Show("Nombre inválido o ya existente.");
            }
        }

        private void butAgrEstilo_Click(object sender, EventArgs e)
        {
            if (cbEstilo.Text != "")
            {
                List<CEstilo> lList = CEstilo.Estilos;
                bool bRepetido = false;
                foreach (CEstilo objeto in lList)
                {
                    if (objeto.Nombre == cbEstilo.Text) { bRepetido = true; }
                }


                if (!bRepetido)
                {
                    CEstilo oEstilo = new CEstilo(cbEstilo.Text);
                    MessageBox.Show($"{cbEstilo.Text} agregado a Estilo.");
                    Actualizar(oEstilo);

                    int cantidad = CEstilo.Estilos.Count;
                    cbEstilo.SelectedIndex = cantidad - 1;
                }
                else { MessageBox.Show($"Ese estilo ya existe."); cbEstilo.Text = ""; }
            }
            else
            {
                MessageBox.Show("Nombre inválido o ya existente.");
            }

        }
    }
}
