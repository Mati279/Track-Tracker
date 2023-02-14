namespace Track_Tracker
{
    public partial class Form1 : Form
    {
        
        //=============================================================================================
        //Instancias -- Instancias -- Instancias -- Instancias -- Instancias -- Instancias -- Instancia
        //=============================================================================================

        //Instanciación de Formas secundarias.
        FAgregarTema fAgregarTema = new FAgregarTema();

        //Instanciación de Perfiles.
        CPerfil Gabi = new CPerfil("Gabi");
        CPerfil Pablo = new CPerfil("Pablo");
        CPerfil Mati = new CPerfil("Matías");

        List<CPerfil> lCPerfiles = new List<CPerfil>();
        //=============================================================================================
        //Atributos -- Atributos -- Atributos -- Atributos -- Atributos -- Atributos -- Atributos -- At
        //=============================================================================================

        //Perfil del usuario.
        CPerfil perfilUsuario;

        //Constructor de Form1.
        public Form1()
        {
            InitializeComponent();
            //Perfil del usuario seteado como Gabi por defecto.
           // cboxPerfiles.SelectedIndex = 0; // 0 Gabi, 1 Mati, 2 Pablo -- Definir que lea el Perfil deseado de algún lado.
        }
       
        //=============================================================================================
        //Handlers  --  Handlers  --  Handlers  --  Handlers  --  Handlers  --  Handlers  --  Handlers  
        //=============================================================================================

        //(Form1_Load) -- (Form1_Load) -- (Form1_Load) -- (Form1_Load) -- (Form1_Load) -- (Form1_Load) 
        private void Form1_Load(object sender, EventArgs e)
        {
            lCPerfiles.Add(Gabi);//Se agregan a la lista de perfiles los 3 predefinidos
            lCPerfiles.Add(Mati);
            lCPerfiles.Add(Pablo);
            cboxPerfiles.DataSource = lCPerfiles;
            cboxPerfiles.ValueMember = "Nombre";


        }
        //|Publicar Tema| -- |Publicar Tema| -- |Publicar Tema| -- |Publicar Tema| -- |Publicar Tema| -
        private void butPublicarTema_Click(object sender, EventArgs e)
        {
            //Envía el objeto CPerfil de quien publicará el tema. 
            fAgregarTema.RecibirPerfil(perfilUsuario);
            fAgregarTema.ShowDialog();
        }

        //|Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Ga
        CPerfil Julio;
        private void butGabi_Click(object sender, EventArgs e)
        {
            Julio = new CPerfil("Julio");
            lCPerfiles.Add(Julio);
            cboxPerfiles.DataSource = null;
            cboxPerfiles.DataSource = lCPerfiles;
        }
        //|Pablo| -- |Pablo| -- |Pablo| -- |Pablo| -- |Pablo| -- |Pablo| -- |Pablo| -- |Pablo| -- |Pabl
        private void butPablo_Click(object sender, EventArgs e)
        {

        }
        //|Mati| -- |Mati| -- |Mati| -- |Mati| -- |Mati| -- |Mati| -- |Mati| -- |Mati| -- |Mati| -- |Ma
        private void butMati_Click(object sender, EventArgs e)
        {

        }

        //|Cambiar Perfil| -- |Cambiar Perfil| -- |Cambiar Perfil| -- |Cambiar Perfil| -- |Cambiar Perfil| -
      
        private void cboxPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            perfilUsuario = (CPerfil)cboxPerfiles.SelectedItem;

          //  MessageBox.Show("perfilUsuario "+ perfilUsuario.Nombre);
        }
    }
}