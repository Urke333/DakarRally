using DakarRally.Enumerations;

namespace DakarRally.Models
{
    public class VehicleTypeValues
    {
        
        public int MaxSpeed { get; private set; }
        public int RepairTime { get; private set; }
        public int LightMalfunctionChance { get; private set; }
        public int HeavyMalfunctionChance { get; private set; }
        public VehicleType VehicleType { get; set; }
        public VehicleSubType VehicleSubType { get; set; }

        public VehicleTypeValues()
        {

        }
        public VehicleTypeValues(int maxSpeed, 
                                 int repairTime, 
                                 int lightMalfunctionChance, 
                                 int heavytMalfunctionChance,
                                 VehicleType vehicleType,
                                 VehicleSubType vehicleSubType)
        {
            MaxSpeed = maxSpeed;
            RepairTime = repairTime;
            LightMalfunctionChance = lightMalfunctionChance;
            HeavyMalfunctionChance = heavytMalfunctionChance;
            VehicleType = vehicleType;
            VehicleSubType = vehicleSubType;
        }

        public void SetVehicleType(VehicleType vehicleType)
        {
            VehicleType = vehicleType;
        }

        public void SetVehicleSubType(VehicleSubType vehicleSubType)
        {
            VehicleSubType = vehicleSubType;
        }

        public void SetMaxSpeed(int maxSpeed)
        {
            MaxSpeed = maxSpeed;
        }
        public void SetRepairTime(int repairTime)
        {
            RepairTime = repairTime;
        }
        public void SetLightMalfunctionChance(int lightMalfunctionChance)
        {
            LightMalfunctionChance = lightMalfunctionChance;
        }
        public void SetHeavyMalfunctionChance(int heavyMalfunctionChance)
        {
            HeavyMalfunctionChance = heavyMalfunctionChance;
        }
    }
}
