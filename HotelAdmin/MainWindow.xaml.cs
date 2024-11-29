using System.Windows;
using HotelAdmin.Models;
using HotelAdmin.Services;
using System.Collections.Generic;

namespace HotelAdmin
{
    public partial class ClientView : Window
    {
        private ClientService _clientService;

        public ClientView()
        {
            InitializeComponent();
            _clientService = new ClientService();
            ChargerClients();
        }
        // Charger les clients dans le ListView

        // Charger les clients dans le ListView
        private void ChargerClients()
        {
            var clients = _clientService.ObtenirTousLesClients();
            ClientListView.ItemsSource = clients;
        }

        // Ajouter un client
        private bool TousLesChampsSontRemplis()
        {
            // Vérifie si tous les champs ont une valeur
            return !string.IsNullOrWhiteSpace(NomTextBox.Text) &&
                   !string.IsNullOrWhiteSpace(EmailTextBox.Text) &&
                   !string.IsNullOrWhiteSpace(TelephoneTextBox.Text) &&
                   !string.IsNullOrWhiteSpace(AdresseTextBox.Text);
        }
        private void AjouterClient_Click(object sender, RoutedEventArgs e)
        {
            if (!TousLesChampsSontRemplis())
            {
                MessageBox.Show("Tous les champs doivent être remplis avant de valider.");
                return;
            }


            var client = new Client
            {
                Nom = NomTextBox.Text,
                Email = EmailTextBox.Text,
                Telephone = TelephoneTextBox.Text,
                Adresse = AdresseTextBox.Text
            };

            _clientService.AjouterClient(client);
            ChargerClients();
            MessageBox.Show("Client ajouté avec succès !");
        }
        private void RechercherClient_Click(object sender, RoutedEventArgs e)
        {
            string recherche = SearchTextBox.Text.ToLower();

            if (!string.IsNullOrEmpty(recherche))
            {
                var clients = _clientService.ObtenirTousLesClients()
                                            .Where(c => c.Nom.ToLower().Contains(recherche) ||
                                                        c.Telephone.Contains(recherche))
                                            .ToList();

                if (clients.Count > 0)
                {
                    ClientListView.ItemsSource = clients; // Met à jour la liste avec les résultats
                }
                else
                {
                    MessageBox.Show("Aucun client trouvé.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom ou un téléphone pour effectuer la recherche.");
            }
        }
        private void ReinitialiserListe_Click(object sender, RoutedEventArgs e)
        {
            ChargerClients(); // Recharge tous les clients
            SearchTextBox.Clear(); // Vide le champ de recherche
        }
        // Modifier un client
        private void ClientListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Vérifiez si un client est sélectionné dans la liste
            if (ClientListView.SelectedItem is Client client)
            {
                // Remplissez les champs du formulaire avec les données du client sélectionné
                NomTextBox.Text = client.Nom ?? string.Empty;
                EmailTextBox.Text = client.Email ?? string.Empty;
                TelephoneTextBox.Text = client.Telephone ?? string.Empty;
                AdresseTextBox.Text = client.Adresse ?? string.Empty;
            }
            else
            {
                // Si aucun client n'est sélectionné, videz les champs
                NomTextBox.Text = string.Empty;
                EmailTextBox.Text = string.Empty;
                TelephoneTextBox.Text = string.Empty;
                AdresseTextBox.Text = string.Empty;
            }
        }

        private void ModifierClient_Click(object sender, RoutedEventArgs e)
        {
            if (!TousLesChampsSontRemplis())
            {
                MessageBox.Show("Tous les champs doivent être remplis avant de valider.");
                return;
            }


            if (ClientListView.SelectedItem is Client client)
            {
                client.Nom = NomTextBox.Text;
                client.Email = EmailTextBox.Text;
                client.Telephone = TelephoneTextBox.Text;
                client.Adresse = AdresseTextBox.Text;

                _clientService.MettreAJourClient(client);
                ChargerClients();
                MessageBox.Show("Client modifié avec succès !");
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client à modifier.");
            }
        }

        // Supprimer un client
        private void SupprimerClient_Click(object sender, RoutedEventArgs e)
        {
            if (ClientListView.SelectedItem is Client client)
            {
                _clientService.SupprimerClient(client.ID);
                ChargerClients();
                MessageBox.Show("Client supprimé avec succès !");
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client à supprimer.");
            }
        }
    }
}
