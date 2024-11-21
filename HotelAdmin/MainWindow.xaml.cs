using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HotelAdmin.Models; // Importer le modèle Client
using HotelAdmin.Services;
namespace HotelAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClientService _clientService;
        public MainWindow()
        {
            InitializeComponent();
            _clientService = new ClientService(); // Initialiser le service
            ChargerClients(); // 
        }
        private void ChargerClients()
        {
            ClientListView.ItemsSource = _clientService.ObtenirTousLesClients();
        }
        private void AjouterClient_Click(object sender, RoutedEventArgs e)
        {
            var client = new Client
            {
                Nom = NomTextBox.Text,
                Email = EmailTextBox.Text,
                Telephone = TelephoneTextBox.Text,
                Adresse = AdresseTextBox.Text
            };
            _clientService.AjouterClient(client);
            ChargerClients(); // Mettre à jour la liste des clients
            MessageBox.Show("Client ajouté avec succès !");
        }
    }
}