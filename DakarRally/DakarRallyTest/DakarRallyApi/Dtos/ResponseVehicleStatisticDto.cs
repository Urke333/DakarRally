using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DakarRallyApi.Dtos
{
    public class ResponseVehicleStatisticDto
    {
        public int Distance { get; set; }
        public List<MalfunctionDto> Malfanctions { get; set; }
        public string Status { get; set; }
        public DateTime? FinishingTime { get; set; }
    }
}
