using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models
{
    public class City
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Address> Addresses { get; set;} = new List<Address>();
    }
}
