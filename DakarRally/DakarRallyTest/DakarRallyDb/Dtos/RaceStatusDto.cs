using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DakarRallyDb.Dtos
{
    public class RaceStatusDto
    {
        public string RaceStatus { get; set; }
        public Dictionary<string, int> GrouByVehicleType { get; set; }
        public Dictionary<string, int> GrouByVehicleStatus { get; set; }
   
    }
}
