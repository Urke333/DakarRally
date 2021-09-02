using DakarRallyDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DakarRallyDb.Dtos
{
    public class VehicleStatisticDto
    {
        public int Distance { get; set; }
        public List<Malfunction> Malfanctions { get; set; }
        public string Status { get; set; }
        public DateTime? FinishingTime { get; set; }


    }
}
