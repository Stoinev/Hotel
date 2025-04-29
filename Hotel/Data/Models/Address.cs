using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models
{
    public class Address
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; } = string.Empty;


        public int CityId { get; set; }
        public City City { get; set; } = null!;

        public ICollection<Client> Clients { get; set;} = new List<Client>();
    }
}
