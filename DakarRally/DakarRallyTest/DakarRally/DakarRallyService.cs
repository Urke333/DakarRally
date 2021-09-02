using DakarRally.Dtos;
using DakarRally.Enumerations;
using DakarRally.Models;
using System;
using System.Collections.Generic;

namespace DakarRally
{
    public class DakarRallyService
    {
        private DbCommunicator dbCommunicator;
        public System.Timers.Timer timer = new System.Timers.Timer();

        public DakarRallyService()
        {
            dbCommunicator = new DbCommunicator();
        }

        public List<Race> CreateRace(int raceYear)
        {
            Year year = new Year(raceYear);
            Race race = new Race(year);
            return dbCommunicator.CreateRace(race);
        }

        public List<Vehicle> AddVehicle(Vehicle vehicle)
        {
            Common.vehicleFactory.SetVehicle(vehicle);
            return dbCommunicator.AddVehicle(vehicle);
        }

        public List<Vehicle> UpdateVehicle(Vehicle updatedVehicle)
        {
            return dbCommunicator.UpdateVehicle(updatedVehicle);
        }

        public List<Vehicle> RemoveVehicle(int id)
        {
            return dbCommunicator.RemoveVehicle(id);
        }

        public List<Vehicle>GetLeaderboard(string vehicleType)
        {
            return dbCommunicator.GetLeaderboard(vehicleType);
        }

        public RaceStatusDto GetRaceStatus(int id)
        {
            return dbCommunicator.GetRaceStatus(id);
        }

        public VehicleStatisticDto GetVehicleStatus(int id)
        {
            return dbCommunicator.GetVehicleStatus(id);
        }

        public void RunRace()
        {
            var currRace = dbCommunicator.FindPendingRace();
            currRace.SetRaceStartTime(DateTime.Now);
            currRace.SetRaceStatus(RaceStatus.Running);
            dbCommunicator.UpdateRace(currRace);

            RaceCalculation raceCalculation = new RaceCalculation(currRace);
            timer.Interval = 1000;//RACE TICK
            timer.Elapsed += raceCalculation.MalfuctionCalculation;
            timer.AutoReset = true;
            timer.Enabled = true;
            raceCalculation.vehicleTickCompleted += RaceCalculation_vehicleTickCompleted;
            raceCalculation.endTheRace += RaceCalculation_endTheRace;         
        }

        private void RaceCalculation_endTheRace(Race currRace)
        {
            timer.Stop();
            currRace.SetRaceStatus(RaceStatus.Finished);
            dbCommunicator.UpdateRace(currRace);
        }

        private void RaceCalculation_vehicleTickCompleted(Vehicle vehicle)
        {
            string s = "";
            dbCommunicator.UpdateVehicleDuringRace(vehicle);
        }
    }
}
