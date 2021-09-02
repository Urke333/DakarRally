using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DakarRallyDb.Models
{
    public class Malfunction
    {
        public int Id { get; set; }
        public int TimeSinceMalfunction { get; set; }
        public string Type { get; set; }
        public bool IsFixed { get; set; }
        public VehicleStatistic VehicleStatistic { get; set; }
        public int VehicleStatisticId { get; set; }
    }
}
