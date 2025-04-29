using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models
{
    public class Client
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50)]
        [Required]
        public string LastName { get; set; } = string.Empty;

        [StringLength(50)]
        [Required]
        public string Phone { get; set; } = string.Empty;

        [StringLength(50)]
        [Required]
        public string Email { get; set; } = string.Empty;

        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;

        public ICollection<Room> Rooms = new List<Room>();
        public ICollection<Reservation> Reservations = new List<Reservation>();
    }
}
