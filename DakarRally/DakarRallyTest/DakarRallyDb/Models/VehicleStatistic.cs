using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DakarRallyDb.Models
{
    public class VehicleStatistic
    {
        public int Id { get; set; }
        public int Distance { get; set; }
        public DateTime? FinishingTime { get; set; }
        public int MaxSpeed { get; set; }
        public int RepairTime { get; set; }
        public string LightMalfunctionChance { get; set; }
        public string HeavyMalfunctionChance { get; set; }

        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        public ICollection<Malfunction> Malfanctions { get; set; }
    }
}
