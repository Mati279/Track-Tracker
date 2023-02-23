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
            Actualizar();
        }

        private void FAgregarArtista_Load(object sender, EventArgs e)
        {

        }

        private void Actualizar()
        {
            cbPaíses.DataSource = null;
            cbPaíses.DataSource = CPaís.Países;
            cbPaíses.DisplayMember = "País";

        }

        private void butOK_Click(object sender, EventArgs e)
        {
            fNombre = tbNombre.Text;
            try { fAño = Convert.ToInt16(tbAño.Text); }
            catch { MessageBox.Show("Introduce un año válido."); }
            fEstilo = (CEstilo)cbEstilo.SelectedItem;
            fPaís = (CPaís)cbPaíses.SelectedItem;


            CArtista nuevoArtista = new CArtista(fNombre, fAño, fPaís, fEstilo);
            this.Close();
            
        }
    }
}
