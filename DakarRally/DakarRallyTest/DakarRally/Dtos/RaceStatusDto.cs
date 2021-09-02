using System;
using System.Collections.Generic;
using System.Text;

namespace DakarRally.Dtos
{
    public class RaceStatusDto
    {
        public string RaceStatus { get; set; }
        public Dictionary<string, int> GrouByVehicleType { get; set; }
        public Dictionary<string, int> GrouByVehicleStatus { get; set; }
    }
}
