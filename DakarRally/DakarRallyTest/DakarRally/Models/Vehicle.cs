using DakarRally.Enumerations;
using System;
using System.Collections.Generic;

namespace DakarRally.Models
{
    public class Vehicle
    {
        public int ID { get; private set; }
        public string TeamName {get;private set;}
        public string Model { get; private set; }
        public DateTime ManufacturingDate { get; private set; }
        public VehicleStatistic VehicleStatistic { get; private set; }
        public VehicleTypeValues VehicleTypeValues { get; private set; }
        public MalfunctionList MalfunctionList { get; protected set; }

        public Vehicle() 
        {
            VehicleStatistic = new VehicleStatistic();
            VehicleTypeValues = new VehicleTypeValues();
            MalfunctionList = new MalfunctionList();
        }
        public Vehicle(VehicleTypeValues vehicleTypeValues)
        {
            VehicleStatistic = new VehicleStatistic();
            VehicleTypeValues = vehicleTypeValues;
            MalfunctionList = new MalfunctionList();
        }

        public int GetMaxSpeed()
        {
            return VehicleTypeValues.MaxSpeed;
        }
        
        public int GetRepairTime()
        {
            return VehicleTypeValues.RepairTime;
        }

        public int GetLightMalfunctionChance()
        {
            return VehicleTypeValues.LightMalfunctionChance;
        }

        public int GetHeavyMalfunctionChance()
        {
            return VehicleTypeValues.LightMalfunctionChance;
        }

        public VehicleType GetVehicleType()
        {
            return VehicleTypeValues.VehicleType;
        }
        public VehicleSubType GetVehicleSubType()
        {
            return VehicleTypeValues.VehicleSubType;
        }

        public List<Malfunction> GetMalfunctions()
        {
            return MalfunctionList.GetMalfunctions();
        }
        public void AddMalfunction(MalfunctionType malfunctionStatus)
        {
            MalfunctionList.AddMalfunction(malfunctionStatus);
        }

        public bool IsThereHeavyMalfunction()
        {
            return MalfunctionList.IsThereHeavyMalfunction();
        }
        public Malfunction GetActiveMalfunction()
        {
            return MalfunctionList.GetActiveMalfunction();
        }

        public int GetMalfunctionCount()
        {
            return MalfunctionList.GetMalfunctionCount();
        }

        public int GetDistance()
        {
            return VehicleStatistic.Distance;
        }

        public VehicleStatus GetVehicleStatus()
        {
            return VehicleStatistic.VehicleStatus;
        }

        public DateTime? GetFinishTime()
        {
            return VehicleStatistic.FinishTime;
        }

        public void SetVehicleStatus(VehicleStatus vehicleStatus)
        {
            VehicleStatistic.SetVehicleStatus(vehicleStatus);
        }

        public void SetVehicleStatistic(VehicleStatistic vehicleStatistic)
        {
            VehicleStatistic = vehicleStatistic;
        }
        public void SetDistance(int distance)
        {
            VehicleStatistic.SetDistance(distance);
        }
        public void SetFinishTime(DateTime? dateTime)
        {
            VehicleStatistic.SetFinishTime(dateTime);
        }

        public void SetTeamName(string teamName)
        {
            TeamName = teamName;
        }
        public void SetModel(string model)
        {
            Model = model;
        }
        public void SetManufacturingDate(DateTime manufacturingDateTime)
        {
            ManufacturingDate = manufacturingDateTime;
        }

        public void SetVehicleType(VehicleType vehicleType)
        {
            VehicleTypeValues.SetVehicleType(vehicleType);
        }

        public void SetVehicleSubType(VehicleSubType vehicleSubType)
        {
            VehicleTypeValues.SetVehicleSubType(vehicleSubType);
        }

        public void SetVehicleId(int id)
        {
            ID = id;
        }
        public void SetVehicleTypeValues(VehicleTypeValues vehicleTypeValues)
        {
            VehicleTypeValues = vehicleTypeValues;
        }

        public void SetMalfunctionList(List<Malfunction> malfunctions)
        {
            MalfunctionList.SetMalfunctionList(malfunctions);
        }
    }
}
