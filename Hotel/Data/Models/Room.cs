using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models
{
    public class Room
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public double Price { get; set; }

        [StringLength(50)]
        [Required]
        public string Description { get; set; } = string.Empty;

        public ICollection<Client> Clients = new List<Client>();
        public ICollection<Reservation> Reservations = new List<Reservation>();
    }
}
