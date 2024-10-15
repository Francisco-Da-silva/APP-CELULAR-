using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace AplicacionCelular
{
    public partial class Form1 : Form
    {
        private List<Celular> ListaCelular;
        public Form1()
        {
            InitializeComponent();
        }

   

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Celularnegocio negocio = new Celularnegocio();
            ListaCelular = negocio.Listar();
            DGVcelular.DataSource = negocio.Listar();
            DGVcelular.Columns["Imagenurl"].Visible = false; //para que no aparezca el url
          
            pictureBox1.Load(ListaCelular[0].Imagenurl);
        }

        private void DGVcelular_SelectionChanged(object sender, EventArgs e)
        {
         
            Celular seleccionado =(Celular) DGVcelular.CurrentRow.DataBoundItem; //la fila actual seleccionada dame el objeto enlasado
            cargarimagen(seleccionado.Imagenurl);
        }

        private void cargarimagen (string imagen) //funcion que se encarga unicamente de cargar una imagen si no la tiene 
        {
            try
            {
                pictureBox1.Load(imagen);
            }
            catch (Exception ex )
            {

                pictureBox1.Load("https://img.freepik.com/vector-gratis/ilustracion-icono-galeria_53876-27002.jpg?semt=ais_hybrid");
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregar Alta = new FormAgregar();
            Alta.ShowDialog();
        }
    }
}
