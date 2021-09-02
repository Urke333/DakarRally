using System.Collections.Generic;
using System.Linq;

namespace DakarRally.Models
{
    public class VehicleList
    {
        public List<Vehicle> Vehicles { get; private set; }

        public VehicleList()
        {
            Vehicles = new List<Vehicle>();
        }

        internal IEnumerable<Vehicle> GetVehicles()
        {
            return Vehicles;
        }

        internal Vehicle GetVehicle(Vehicle vehicle)
        {
            return Vehicles.FirstOrDefault(v => v.ID == vehicle.ID);
        }

        internal Vehicle GetVehicleById(int id)
        {
            return Vehicles.FirstOrDefault(v => v.ID == id);
        }

        internal void SetVehicleList(List<Vehicle> vehicles)
        {
            Vehicles = vehicles;
        }
    }
}
