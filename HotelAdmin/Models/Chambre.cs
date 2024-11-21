using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAdmin.Models
{
    public class Chambre
    {
        public int ID { get; set; }
        public string Numero { get; set; } // Numéro de la chambre
        public bool EstDisponible { get; set; } // Disponibilité de la chambre
        public DateTime? DateDebut { get; set; } // Date de début d'occupation
        public DateTime? DateFin { get; set; } // Date de fin d'occupation

        // Clé étrangère vers TypeChambre
        public int TypeChambreID { get; set; }

        // Propriété de navigation vers TypeChambre
        public TypeChambre TypeChambreAssocie { get; set; }
    }

}
