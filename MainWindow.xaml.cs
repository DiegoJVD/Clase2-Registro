using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using Microsoft.EntityFrameworkCore;

namespace Clase2_Registro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
          private Actores actor;
        public MainWindow()
        {
            InitializeComponent();
            actor = new Actores();
        }

        public void GuardarButton_Click(object sender, RoutedEventArgs e){
            Contexto context = new Contexto();

            
            actor.Nombres = NombresTextbox.Text ;
            actor.SalarioAnual =Convert.ToDecimal(SalarioTextbox.Text);

            context.Actores.Add(actor);
            int cant = context.SaveChanges();

            context.Dispose();

            if(cant > 0){
                MessageBox.Show("Guardo !");
                actor = new Actores();
                DataContext = actor;
            }
        }

        public void BuscarButton_Click(object render, RoutedEventArgs e){
            
            Contexto context = new Contexto();

            var found = context.Actores.Find(Convert.ToInt32(ActorIDTextBox.Text));

            if(found != null){
                actor = found;
                NombresTextbox.Text = actor.Nombres;
                SalarioTextbox.Text = Convert.ToString(actor.SalarioAnual);
            }   

            context.Dispose();
        }
    }

    

   
}
