namespace Track_Tracker
{
    public partial class Form1 : Form
    {
        
        //Instanciación de Formas secundarias.
        FAgregarTema fAgregarTema = new FAgregarTema();

        //Instanciación de Perfiles y lista de perfiles.
        CPerfil Gabi = new CPerfil("Gabi");
        CPerfil Pablo = new CPerfil("Pablo");
        CPerfil Mati = new CPerfil("Matías");

        List<CPerfil> lCPerfiles = new List<CPerfil>();
       


        //Constructor de Form1.
        public Form1()
        {
            InitializeComponent();

        }
       
       

        private void Form1_Load(object sender, EventArgs e)
        {
            //Se agregan a la lista de perfiles los 3 predefinidos
            lCPerfiles.Add(Gabi);
            lCPerfiles.Add(Mati);
            lCPerfiles.Add(Pablo);

            //Gabi por defecto, acá habría que hacer lo del archivo para que recuerde la setting local.
            CPerfil.perfilUsuario = Gabi;

            ActualizarCBPerfiles();
        }


        private void butPublicarTema_Click_1(object sender, EventArgs e) //Tuve que agregar _1 al final del nombre del evento, no sé por qué.
        {
           fAgregarTema.ShowDialog();
        }

       
        private void butGabi_Click(object sender, EventArgs e)
        {
            CPerfil Julio = new CPerfil("Julio");
            lCPerfiles.Add(Julio);

            ActualizarCBPerfiles();

        }
        private void butPablo_Click(object sender, EventArgs e)
        {

        }
        private void butMati_Click(object sender, EventArgs e)
        {

        }

        private void cboxPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            CPerfil.perfilUsuario = (CPerfil)cboxPerfiles.SelectedItem;

            CPerfil.perfilUsuario ??= Gabi;

            lbViendo.Text = CPerfil.perfilUsuario.Nombre;
          
        }

        private void ActualizarCBPerfiles()
        {
            cboxPerfiles.DataSource = null;
            cboxPerfiles.DataSource = lCPerfiles;
            cboxPerfiles.DisplayMember = "Nombre";
        }
       
    }
}