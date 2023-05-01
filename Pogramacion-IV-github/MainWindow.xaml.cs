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

namespace GitHub_programacion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbController DbController = new DbController();
        public MainWindow()
        {
            InitializeComponent();
            dg.ItemsSource = new List<Estudiante>();
        }

        private void btnguardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DbController.BuscarEstudiante(tbmat.Text).Count == 0)
                {
                    DbController.GuardarEstudiante(new Estudiante
                    {
                        Nombre = tbname.Text,
                        Matricula = tbmat.Text
                    });
                    tbname.Text = null;
                    tbmat.Text = null;
                }
                else
                {
                    MessageBox.Show("La matricula digitada ya esta registrada", "Aviso");
                }

            }
            catch (Exception r)
            {
                MessageBox.Show("No fue posible guardar los datos: " + r.Message, "Error");
            }
        }

        private void btnbuscar_Click(object sender, RoutedEventArgs e)
        {
            if (tbbuscar.Text != "")
            {
                try
                {
                    dg.ItemsSource = DbController.BuscarEstudiante(tbbuscar.Text);
                }
                catch (Exception r)
                {

                    MessageBox.Show("No fue posible realizar la busqueda: " + r.Message, "Error");

                }
            }
            else
            {
                MessageBox.Show("Coloca la matricula que deseas buscar");
                tbbuscar.Focus();
            }
        }

        private void btntodo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dg.ItemsSource = DbController.Estudiantes.ToList();
            }
            catch (Exception r)
            {

                MessageBox.Show("La base de datos se encuentra \r\nvacia y/o \r\ninaccesible : "+r,"Error");
            }
        }
    }
}