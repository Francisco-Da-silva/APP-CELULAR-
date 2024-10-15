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
    public partial class FormAgregar : Form
    {
        public FormAgregar()
        {
            InitializeComponent();
        }

     

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Celular celu = new Celular();
            Celularnegocio Negocio = new Celularnegocio();


            try
            {

                celu.Codigo = TextCodigo.Text;
                celu.Nombre = TextNombre.Text;
                celu.Descripcion = TextDescripcion.Text;
                celu.Marcas = (Categoria)CboMarca.SelectedItem;
                celu.Tipo = ( Categoria)CboCategoria.SelectedItem;

            //
            //Celu.Modelo = (Categoria)CboModelo.SelectedItem;
            //    Celu.Tipo = (Categoria)CboTipo.SelectedItem;
            



                Negocio.Agregar(celu);
                MessageBox.Show("Agregado exitosamente ");
                Close(); 



            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void FormAgregar_Load(object sender, EventArgs e)
        {
            CategoriaNegocio CategoriaNegocio = new CategoriaNegocio(); //cargo los desplegables
            try
            {
               // CboMarca.DataSource = MarcasNegocio.Listar();
                CboCategoria.DataSource = CategoriaNegocio.Listar();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

 
    }
}
