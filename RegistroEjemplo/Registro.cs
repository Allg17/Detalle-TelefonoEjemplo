using RegistroEjemplo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroEjemplo
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        //Esta es la clase en donde va la programacion del formulario del registro
        // aqui llamamos toda la programacion logica creada en la BLL

        private void LlenarComboBox()
        {
            TipocomboBox.Items.Add("Casa");
            TipocomboBox.Items.Add("Celular");
            TipocomboBox.Items.Add("Trabajo");

        }

        Persona people = new Persona();
        public int RowSelected { get; set; }
        List<TelefonoDetalle> Detalle = new List<TelefonoDetalle>();
        private void Nuevo_Click(object sender, EventArgs e)
        {
            //Este es el evento click del boton nuevo, este metodo limpia la ventana.
            IDnumericUpDown.Value = 0;
            NombretextBox.Clear();
            CedulamaskedTextBox.Clear();
            DirecciontextBox.Clear();
            TelefonomaskedTextBox.Clear();
            TipocomboBox.Text = string.Empty;
            ModificarnumericUpDown1.Value = 0;
            TelefonodataGridView.DataSource = null;
            people = new Persona();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            //Este es el evento del boton guardar, aqui se llama el metodo guardar creado en la BLL de PersonaBLL y el metodo modificar

            Persona persona = LlenaClase();

            if (IDnumericUpDown.Value == 0)
            {
                if (BLL.PersonaBLL.Guardar(persona))
                {
                    MessageBox.Show("Guardado!!");
                }
                else
                {
                    MessageBox.Show("No se pudo guardar!!");
                }
            }
            else
            {
                if (BLL.PersonaBLL.Modificar(LlenaClase()))
                {
                    MessageBox.Show("Modificado!!");
                    if (Detalle.Count != 0)
                    {
                        foreach (var item in Detalle)
                        {
                            BLL.PersonaBLL.EliminarDetalle(item.Id);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("No se pudo Modificar!!");
                }
            }
        }

        private Persona LlenaClase()
        {
            //Este es el metodo para llenar la clase persona 
            //Persona persona = new Persona();

            people.IdPersona = Convert.ToInt32(IDnumericUpDown.Value);
            people.Nombre = NombretextBox.Text;
            people.Cedula = CedulamaskedTextBox.Text;
            people.Direccion = DirecciontextBox.Text;
            return people;
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            //El evento para eliminar una persona de la base de datos
            int id = Convert.ToInt32(IDnumericUpDown.Value);
            if (BLL.PersonaBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!");
            }
            else
            {
                MessageBox.Show("No se pudo eliminar!!");
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            //Este evento busca en la base de datos y lo agrega a los campos

            int id = Convert.ToInt32(IDnumericUpDown.Value);
            var persona = BLL.PersonaBLL.Buscar(id);
            if (persona != null)
            {
                NombretextBox.Text = persona.Nombre;
                CedulamaskedTextBox.Text = persona.Cedula;
                DirecciontextBox.Text = persona.Direccion;
                TelefonodataGridView.DataSource = null;
                TelefonodataGridView.DataSource = persona.Telefono;
                people.Telefono = persona.Telefono;

            }
            else
            {
                MessageBox.Show("No se encontro!");
            }

        }

        private void Consultabutton_Click(object sender, EventArgs e)
        {
            cPersonas abrir = new cPersonas();
            abrir.Show();
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            if (IDnumericUpDown.Value == 0)
            {
                people.Telefono.Add(new TelefonoDetalle(Convert.ToInt32(IDnumericUpDown.Value), TipocomboBox.Text, TelefonomaskedTextBox.Text));
            }
            else
            {
                if (people.Telefono.Exists(t => t.Telefono == TelefonomaskedTextBox.Text))
                {
                    MessageBox.Show("El numero existe");
                }
                else
                {
                    if (ModificarnumericUpDown1.Value != 0)
                    {
                        foreach (var item in people.Telefono)
                        {
                            if (item.Id == Convert.ToInt32(ModificarnumericUpDown1.Value))
                            {
                                item.TipoTelefono = TipocomboBox.Text;
                                item.Telefono = TelefonomaskedTextBox.Text;
                            }

                        }
                    }
                    else
                    {
                        people.Telefono.Add(new TelefonoDetalle(Convert.ToInt32(IDnumericUpDown.Value), TipocomboBox.Text, TelefonomaskedTextBox.Text));
                    }
                }


            }
            TelefonodataGridView.DataSource = null;
            TelefonodataGridView.DataSource = people.Telefono;
        }

        private void TraerNumeroButton_Click(object sender, EventArgs e)
        {
            foreach (var item in people.Telefono)
            {
                if (item.Id == Convert.ToInt32(ModificarnumericUpDown1.Value))
                {
                    TipocomboBox.Text = item.TipoTelefono;
                    TelefonomaskedTextBox.Text = item.Telefono;

                }
            }
        }

        private void TelefonodataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowSelected = e.RowIndex;
        }

        private void EliminarDetallebutton_Click(object sender, EventArgs e)
        {
            if (RowSelected >= 0)
            {

                TelefonoDetalle tel = people.Telefono.ElementAt(RowSelected);
                Detalle.Add(new TelefonoDetalle(tel.Id, tel.IdPersona, tel.TipoTelefono, tel.Telefono));
                people.Telefono.RemoveAt(RowSelected);
                TelefonodataGridView.DataSource = null;
                TelefonodataGridView.DataSource = people.Telefono;
                RowSelected = -1;
                MessageBox.Show("Eliminado!");
            }
        }
    }
}
