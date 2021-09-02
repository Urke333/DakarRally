using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DakarRallyDb.Models
{
    public class Race
    {
        //public int Id { get; set; }
        [Key]
        public int Year { get; set; }
        public string Status { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
