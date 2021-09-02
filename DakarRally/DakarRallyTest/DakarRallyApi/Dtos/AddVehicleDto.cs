using System;
using System.ComponentModel.DataAnnotations;

namespace DakarRallyApi.Dtos
{
    public class AddVehicleDto
    {
        [Required]
        public string VehicleType { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public DateTime ManufacturingDate { get; set; }

        public string SubType { get; set; }
    }
}
