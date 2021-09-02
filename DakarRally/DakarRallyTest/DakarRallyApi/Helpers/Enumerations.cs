using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DakarRallyApi.Helpers
{
    public class Enumerations
    {
        public enum RaceStatus
        {
            Pending,
            Running,
            Finished
        }

        public enum MalfunctionStatus
        {
            None,
            Light,
            Heavy
        }

        public enum VehicleType
        {
            Car,
            Truck,
            Motorcycle
        }

        public enum VehicleSubType
        {
            Sports,
            Terrain,
            Truck,
            Cross,
            Sport
        }

        public enum VehicleStatus
        {
            Pending,
            Light,
            Heavy,
            Running,
            Finished
        }
    }
}
