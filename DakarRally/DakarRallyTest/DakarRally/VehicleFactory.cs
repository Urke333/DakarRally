using DakarRally.Enumerations;
using DakarRally.Models;
using System;

namespace DakarRally
{
    public class VehicleFactory
    {
        public Vehicle SetVehicle(Vehicle vehicle)
        {
            VehicleType vehicleType = vehicle.GetVehicleType();
            VehicleSubType vehicleSubType = vehicle.GetVehicleSubType();
            VehicleTypeValues vehicleTypeValues = null;
            vehicle.SetVehicleStatus(VehicleStatus.Operational);

            if (vehicleType == VehicleType.Car && String.Equals(vehicleSubType, VehicleSubType.Sports))
            {
                vehicleTypeValues = new VehicleTypeValues((int)VehicleMaxSpeed.SportCarMaxSpeed, 
                                                          (int)VehicleRepairTime.Car,
                                                          (int)MalfunctionChances.SportCarLight,
                                                          (int)MalfunctionChances.SportCarHeavy,
                                                          VehicleType.Car,
                                                          VehicleSubType.Sports
                                                         );
                
            }
            else if (vehicleType == VehicleType.Car && String.Equals(vehicleSubType, VehicleSubType.Terrain))
            {
                vehicleTypeValues = new VehicleTypeValues((int)VehicleMaxSpeed.TerrainCarMaxSpeed,
                                                          (int)VehicleRepairTime.Car,
                                                          (int)MalfunctionChances.TerrainCarLight,
                                                          (int)MalfunctionChances.TerrainCarHeavy,
                                                          VehicleType.Car,
                                                          VehicleSubType.Terrain
                                                         );
            }
            else if(vehicleType == VehicleType.Truck && String.Equals(vehicleSubType, VehicleSubType.Truck))
            {
                vehicleTypeValues = new VehicleTypeValues((int)VehicleMaxSpeed.TruckMaxSpeed,
                                                         (int)VehicleRepairTime.Truck,
                                                         (int)MalfunctionChances.TruckLight,
                                                         (int)MalfunctionChances.TruckHeavy,
                                                         VehicleType.Truck,
                                                         VehicleSubType.Truck
                                                        );
            }
            else if (vehicleType == VehicleType.Motorcycle && String.Equals(vehicleSubType, VehicleSubType.Cross))
            {
                vehicleTypeValues = new VehicleTypeValues((int)VehicleMaxSpeed.CrossMotorcycleMaxSpeed,
                                                          (int)VehicleRepairTime.Motorcycle,
                                                          (int)MalfunctionChances.CrossMotorcycleLight,
                                                          (int)MalfunctionChances.CrossMotorcycleHeavy,
                                                          VehicleType.Motorcycle,
                                                          VehicleSubType.Cross
                                                         );
            }
            else if (vehicleType == VehicleType.Motorcycle && String.Equals(vehicleSubType, VehicleSubType.Sport))
            {
                vehicleTypeValues = new VehicleTypeValues((int)VehicleMaxSpeed.SportMotorcycle,
                                                          (int)VehicleRepairTime.Motorcycle,
                                                          (int)MalfunctionChances.SportMotorcycleLight,
                                                          (int)MalfunctionChances.SportMotorcycleHeavy,
                                                          VehicleType.Motorcycle,
                                                          VehicleSubType.Sport
                                                         );
            }
            else
                throw new InvalidOperationException("Vehicle type does not exist.");

            vehicle.SetVehicleTypeValues(vehicleTypeValues);
            return vehicle;
        }
    }
}
