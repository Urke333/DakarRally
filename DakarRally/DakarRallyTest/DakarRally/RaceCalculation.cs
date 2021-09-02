using DakarRally.Enumerations;
using DakarRally.Models;
using System;
using System.Linq;
using System.Timers;

namespace DakarRally
{
    public delegate void VehicleTick(Vehicle vehicle);
    public delegate void EndRace(Race race);
    public class RaceCalculation
    {
        public Random randomNumberGenerator { get; private set; }
        public Race Race { get; private set; }
        public object locker = new object();
        public event VehicleTick vehicleTickCompleted;
        public event EndRace endTheRace;


        public RaceCalculation(Race race)
        {
            Race = race;
            randomNumberGenerator = new Random();
        }
        internal void MalfuctionCalculation(object sender, ElapsedEventArgs e)
        {
            lock (locker)
            {
                foreach (var veh in Race.GetVehicles())
                {
                    CheckMalfunctionStatus(veh);
                    vehicleTickCompleted(veh);
                }
                if (!Race.GetVehicles().Any( o =>!o.IsThereHeavyMalfunction() && !o.GetFinishTime().HasValue))
                {
                    endTheRace(Race);
                }
            }            
        }

        private void CheckMalfunctionStatus(Vehicle vehicle)
        {           
            var raceStartTime = Race.GetRaceStartTime();

            if (vehicle.IsThereHeavyMalfunction() || vehicle.GetFinishTime().HasValue)
            {
                return;
            }
            Malfunction lightMalfunction = vehicle.GetActiveMalfunction();

            if (lightMalfunction != null)
            {
                lightMalfunction.IncreaseTimeSinceMalfunction();
                if (lightMalfunction.TimeSinceMalfunction >= vehicle.GetRepairTime())
                {
                    vehicle.SetVehicleStatus(VehicleStatus.Operational);
                    lightMalfunction.SetTimeSinceMalfunction(0);
                    lightMalfunction.SetIsFixed(true);
                }
            }
            else
            {
                int randomNumber = randomNumberGenerator.Next(1, 100);
                if (randomNumber <= vehicle.GetHeavyMalfunctionChance())
                {
                    vehicle.SetVehicleStatus(VehicleStatus.Heavy);
                    vehicle.AddMalfunction(MalfunctionType.Heavy);
                }
                else if (randomNumber <= vehicle.GetLightMalfunctionChance())
                {
                    vehicle.SetVehicleStatus(VehicleStatus.Light);
                    vehicle.AddMalfunction(MalfunctionType.Light);
                }

                if (vehicle.GetVehicleStatus() == VehicleStatus.Operational)
                {
                    vehicle.SetDistance(vehicle.GetMaxSpeed());
                    if (vehicle.GetDistance() >= Common.trackLength)
                    {
                        int raceTimeInSeconds = Common.trackLength * 3600 / vehicle.GetMaxSpeed();
                        int repairTimeInSeconds = vehicle.GetMalfunctionCount() * vehicle.GetRepairTime() * 3600;
                        int totalRaceTimeInSeconds = raceTimeInSeconds + repairTimeInSeconds;
                        vehicle.SetFinishTime(raceStartTime.AddSeconds(totalRaceTimeInSeconds));
                    }
                }
            }
        }
    }
}
