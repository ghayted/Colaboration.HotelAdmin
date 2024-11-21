using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAdmin.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public DateTime DateCreation { get; set; } // Date de création de la réservation
        public string Statut { get; set; } // Statut de la réservation
        public DateTime DateArrivee { get; set; } // Date d'arrivée prévue
        public DateTime DateDepart { get; set; } // Date de départ prévue

        // Clés étrangères
        public int ClientID { get; set; }
        public int ChambreID { get; set; }
        public int EmployeID { get; set; }

        // Propriétés de navigation
        public Client ClientAssocie { get; set; }
        public Chambre ChambreAssociee { get; set; }
        public Employe EmployeAssocie { get; set; }
        public ICollection<Paiement> PaiementsAssocies { get; set; }
    }

}
