using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistroPersonas_Tarea2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Personas Persona = new Personas();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            this.Persona = new Personas();
            this.DataContext = Persona;
        }

        private bool Validar()
        {
            bool valido = true;

            if(NombreTextBox.Text.Length == 0)
            {
                valido = false;
                MessageBox.Show("Error, persona no valida.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return valido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var persona = PersonasBLL.Buscar(Convert.ToInt32(PersonaIdTextBox.Text));
            if(Persona != null)
            {
                this.Persona = persona;
            }
            else
            {
                this.Persona = new Personas();
            }
            this.DataContext = this.Persona;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }  

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if(!Validar())
                return;
            
            var guardo = PersonasBLL.Guardar(Persona);

            if(guardo)
            {
                Limpiar();
                MessageBox.Show("Se guardó exitosamente.", "¡Exito!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar la persona.", "¡Fallo!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if(PersonasBLL.Eliminar(Convert.ToInt32(PersonaIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Se eliminó exitosamente.", "¡Exito!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la persona.", "¡Fallo!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
