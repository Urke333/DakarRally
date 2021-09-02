using System;

namespace DakarRallyApi.Dtos
{
    public class UpdateVehicleDto
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string TeamName { get; set; }
        public string Model { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public string SubType { get; set; }
    }
}
