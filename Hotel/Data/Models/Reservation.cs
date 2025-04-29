using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models
{
    public class Reservation
    {
        public int ClientId { get; set; }

        public int RoomId { get; set; }

        public Client Client { get; set; } = null!;

        public Room Room { get; set; } = null!;

        public DateTime Date { get; set; }

        public int Days { get; set; }
    }
}
