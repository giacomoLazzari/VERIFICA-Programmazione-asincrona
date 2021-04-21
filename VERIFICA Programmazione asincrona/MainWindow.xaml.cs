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
using System.Threading;

namespace VERIFICA_Programmazione_asincrona
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Char[] lettere;
        int maxLettere;
        string parola;
        public MainWindow()
        {
            InitializeComponent();
            lettere = new char[10];
            lettere[0] = 'a';
            lettere[1] = 'b';
            lettere[2] = 'c';
            lettere[3] = 'd';
            lettere[4] = 'e';
            lettere[5] = 'f';
            lettere[6] = 'g';
            lettere[7] = 'h';
            lettere[8] = 'i';
            lettere[9] = 'm';
            maxLettere = 0;
            SorteggioLettere();
            
        }

        private async void SorteggioLettere()
        {
            Random rnd = new Random();
            await Task.Run(() =>
            {
                while (true)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        lblSorteggioLettera.Content = lettere[rnd.Next(0, 9)];
                        
                    }));
                    Thread.Sleep(10);
                }
            });
        }

        private void btnLunghezza_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                maxLettere = int.Parse(txtNLettere.Text);
                txtNLettere.Text = "";
                parola = "";
                lblParolaSorteggiata.Content = "";
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSorteggiaLettera_Click(object sender, RoutedEventArgs e)
        {
            Char lettera = (char)lblSorteggioLettera.Content;
            parola += lettera;
            if(maxLettere!= 0 && parola.Length>= maxLettere)
            {
                lstParole.Items.Add(parola);
                parola = "";
                
            }
            lblParolaSorteggiata.Content = parola;
        }
    }
}
