using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAdmin.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Nom { get; set; } // Nom du client
        public string Email { get; set; } // Email du client
        public string Telephone { get; set; } // Téléphone du client
        public string Adresse { get; set; } // Adresse du client

        // Propriétés de navigation vers les réservations et notifications associées
        public ICollection<Reservation> ReservationsAssociees { get; set; }
        public ICollection<Notification> NotificationsAssociees { get; set; }
    }

}
