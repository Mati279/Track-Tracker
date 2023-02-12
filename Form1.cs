namespace Track_Tracker
{
    public partial class Form1 : Form
    {
        #region//Instanciaciones.
        //=============================================================================================
        //Instancias -- Instancias -- Instancias -- Instancias -- Instancias -- Instancias -- Instancia
        //=============================================================================================

        //Instanciación de Formas secundarias.
        //Forma Agregar Temas.
        FAgregarTema fAgregarTema = new FAgregarTema();

        #endregion

        //Constructor de Form1.
        public Form1()
        {
            InitializeComponent();
        }

        #region//Handlers.
        //=============================================================================================
        //Handlers  --  Handlers  --  Handlers  --  Handlers  --  Handlers  --  Handlers  --  Handlers  
        //=============================================================================================

        //Form1_Load -- Form1_Load -- Form1_Load -- Form1_Load -- Form1_Load -- Form1_Load -- Form1_Loa 
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //|Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Gabi| -- |Ga
        private void butGabi_Click(object sender, EventArgs e)
        {
            fAgregarTema.ShowDialog();

        }

        #endregion
    }
}