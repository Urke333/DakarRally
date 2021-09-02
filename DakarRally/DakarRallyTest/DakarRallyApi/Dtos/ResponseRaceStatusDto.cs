using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DakarRallyApi.Dtos
{
    public class ResponseRaceStatusDto
    {
        public string RaceStatus { get; set; }
        public Dictionary<string, int> GrouByVehicleType { get; set; }
        public Dictionary<string, int> GrouByVehicleStatus { get; set; }
    }
}
