using DakarRally.Enumerations;
using System;

namespace DakarRally.Models
{
    public class VehicleStatistic
    {
        public int Distance { get; private set; }
        public VehicleStatus VehicleStatus { get; private set; }
        public DateTime? FinishTime { get; private set; }

        public VehicleStatistic()
        {
        }

        public void SetVehicleStatus(VehicleStatus vehicleStatus)
        {
            VehicleStatus = vehicleStatus;
        }
        public void SetDistance(int distance)
        {
            Distance += distance;
        }
        public void SetFinishTime(DateTime? finishTime)
        {
            FinishTime = finishTime;
        }
    }
}
