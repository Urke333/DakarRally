using DakarRallyDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DakarRallyDb
{
    internal static class Validation
    {
        internal static bool CheckIfTypeDoesNotExist(Vehicle updatedVehicle)
        {
            if (updatedVehicle.VehicleType.ToLower() != CommonVariables.carType.ToLower() &&
                updatedVehicle.VehicleType.ToLower() != CommonVariables.truckType.ToLower() &&
                updatedVehicle.VehicleType.ToLower() != CommonVariables.motorcycleType.ToLower())
                    return false;
            return true;
        }


        internal static bool CheckIfSubTypeDoesNotExist(Vehicle updatedVehicle)
        {
            if (updatedVehicle.SubType.ToLower() != CommonVariables.sportsCarSubType.ToLower() &&
                updatedVehicle.SubType.ToLower() != CommonVariables.terrainCarSubType.ToLower() &&
                updatedVehicle.SubType.ToLower() != CommonVariables.truck.ToLower() &&
                updatedVehicle.SubType.ToLower() != CommonVariables.crossMotorcycleSubType.ToLower() &&
                updatedVehicle.SubType.ToLower() != CommonVariables.sportMotorcycleSubType.ToLower())
                return false;
            return true;
        }
    }
}
