using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DakarRallyDb.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string TeamName { get; set; }
        public string Model { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public string SubType { get; set; }
        public string Status { get; set; }
        public VehicleStatistic VehicleStatistic { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
    }
}
