using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelAdmin.Data;
using HotelAdmin.Models;
namespace HotelAdmin.Services
{
    public class ClientService
    {
        // Ajouter un client
        public void AjouterClient(Client client)
        {
            using (var context = new HotelDbContext())
            {
                context.ClientsDB.Add(client);
                context.SaveChanges();
            }
        }

        // Obtenir tous les clients
        public List<Client> ObtenirTousLesClients()
        {
            using (var context = new HotelDbContext())
            {
                return context.ClientsDB.ToList();
            }
        }

        // Obtenir un client par ID
        public Client ObtenirClientParID(int id)
        {
            using (var context = new HotelDbContext())
            {
                return context.ClientsDB.Find(id);
            }
        }

        // Mettre à jour un client
        public void MettreAJourClient(Client client)
        {
            using (var context = new HotelDbContext())
            {
                context.ClientsDB.Update(client);
                context.SaveChanges();
            }
        }

        // Supprimer un client
        public void SupprimerClient(int id)
        {
            using (var context = new HotelDbContext())
            {
                var client = context.ClientsDB.Find(id);
                if (client != null)
                {
                    context.ClientsDB.Remove(client);
                    context.SaveChanges();
                }
            }
        }
    }
}