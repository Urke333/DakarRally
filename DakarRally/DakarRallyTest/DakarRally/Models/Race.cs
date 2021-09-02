using DakarRally.Enumerations;
using System;
using System.Collections.Generic;

namespace DakarRally.Models
{
    public class Race
    {

        public int Year { get; private set; }
        public VehicleList Vehicles { get; private set; }

        public RaceStatus Status { get; private set; }
        public RaceTickInformation raceTickInformation { get; private set; }

        public Race() 
        {
            Vehicles = new VehicleList();
            Status = RaceStatus.Pending;
            raceTickInformation = new RaceTickInformation();
        }
        public Race(Year year) 
        {
            Year = year.YearDate;
            Vehicles = new VehicleList();
            Status = RaceStatus.Pending;
            raceTickInformation = new RaceTickInformation();
        }

        public void SetYear(int year)
        {
            Year = year;
        }

        public void SetStatus(RaceStatus raceStatus)
        {
            Status = raceStatus;
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return Vehicles.GetVehicles();
        }

        public void SetRaceStatus(RaceStatus raceStatus)
        {
            Status = raceStatus;
        }

        public void SetRaceStartTime(DateTime startTime)
        {
            raceTickInformation.SetRaceStartTime(startTime);
        }
        public DateTime GetRaceStartTime()
        {
            return raceTickInformation.RaceStartTime;
        }

        public void SetVehicleList(List<Vehicle> vehicles)
        {
            Vehicles.SetVehicleList(vehicles);
        }
    }
}
