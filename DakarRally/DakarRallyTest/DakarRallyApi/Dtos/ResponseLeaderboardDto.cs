using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DakarRallyApi.Dtos
{
    public class ResponseLeaderboardDto
    {
        public int Distance { get; set; }
        public string VehicleType { get; set; }
        public string TeamName { get; set; }
        public string Model { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public string SubType { get; set; }
    }
}
