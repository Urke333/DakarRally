using DakarRallyDb.Models;
using DakarRally.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Vehicle = DakarRally.Models.Vehicle;
using Race = DakarRally.Models.Race;
using VehicleStatistic = DakarRally.Models.VehicleStatistic;
using VehiclesTypeValues = DakarRally.Models.VehicleTypeValues;
using Malfunction = DakarRally.Models.Malfunction;
using VehicleDb = DakarRallyDb.Models.Vehicle;
using RaceDb = DakarRallyDb.Models.Race;
using VehicleStatisticDb = DakarRallyDb.Models.VehicleStatistic;
using MalfunctionDb = DakarRallyDb.Models.Malfunction;
using RaceStatusDtoModel = DakarRally.Dtos.RaceStatusDto;
using RaceStatusDtoModelDb = DakarRallyDb.Dtos.RaceStatusDto;
using VehicleStatisticDtoModel = DakarRally.Dtos.VehicleStatisticDto;
using VehicleStatisticDtoDb = DakarRallyDb.Dtos.VehicleStatisticDto;



namespace DakarRally
{
    internal static class Converter
    {
        internal static VehicleDb ModelEntityToDbVehicle(Vehicle vehicle)
        {
            VehicleDb vehicleDb = new VehicleDb();
            vehicleDb.Id = vehicle.ID;
            vehicleDb.Model = vehicle.Model;
            vehicleDb.ManufacturingDate = vehicle.ManufacturingDate;
            vehicleDb.TeamName = vehicle.TeamName;
            vehicleDb.VehicleType = vehicle.GetVehicleType().ToString();
            vehicleDb.SubType = vehicle.GetVehicleSubType().ToString();
            vehicleDb.Status = vehicle.GetVehicleStatus().ToString();
            return vehicleDb;
        }

        internal static Vehicle DbToModelEntityVehicle(VehicleDb vehicleDb)
        {
            Vehicle vehicle = new Vehicle();
            vehicle.SetVehicleId(vehicleDb.Id);
            vehicle.SetTeamName(vehicleDb.TeamName);
            vehicle.SetModel(vehicleDb.Model);
            vehicle.SetManufacturingDate(vehicleDb.ManufacturingDate);
            var vehicleType = VehicleTypeEnumerationConversion(vehicleDb.VehicleType);
            var vehicleSubType = VehicleSubTypeEnumerationConversion(vehicleDb.SubType);
            vehicle.SetVehicleType(vehicleType);
            vehicle.SetVehicleSubType(vehicleSubType);
            vehicle.SetVehicleStatus(VehicleStatusEnumerationConversion(vehicleDb.Status));
            return vehicle;
        }

        internal static RaceDb ModelEntityToDbRace(Race race)
        {
            RaceDb raceDb = new RaceDb();
            raceDb.Year = race.Year;
            raceDb.Status = race.Status.ToString();
            return raceDb;
        }

        internal static Race DbToModelEntityRace(RaceDb raceDb)
        {
            var race = new Race();
            race.SetYear(raceDb.Year);
            var raceStatus = RaceStatuseEnumerationConversion(raceDb.Status);
            race.SetStatus(raceStatus);
            return race;
        }

        internal static VehicleTypeValues DbToModelEntityVehicleTypeValues( VehicleDb vehicleDb)
        {
            VehicleTypeValues vehicleTypeValues = new VehiclesTypeValues();
            var vehicleStatisticDb = vehicleDb.VehicleStatistic;
            vehicleTypeValues.SetHeavyMalfunctionChance(Int32.Parse(vehicleStatisticDb.HeavyMalfunctionChance.Replace("%", String.Empty)));
            vehicleTypeValues.SetLightMalfunctionChance(Int32.Parse(vehicleStatisticDb.LightMalfunctionChance.Replace("%", String.Empty)));
            vehicleTypeValues.SetMaxSpeed(vehicleStatisticDb.MaxSpeed);
            vehicleTypeValues.SetRepairTime(vehicleStatisticDb.RepairTime);
            vehicleTypeValues.SetVehicleType(VehicleTypeEnumerationConversion(vehicleDb.VehicleType));
            vehicleTypeValues.SetVehicleSubType(VehicleSubTypeEnumerationConversion(vehicleDb.SubType));
            return vehicleTypeValues;
        }

        internal static VehicleStatisticDb ModelEntityToDbVehicleStatistic(Vehicle vehicle)
        {
            VehicleStatisticDb vehicleStatisticDb = new VehicleStatisticDb();
            vehicleStatisticDb.VehicleId = vehicle.ID;
            vehicleStatisticDb.Distance = vehicle.GetDistance();
            vehicleStatisticDb.FinishingTime = vehicle.GetFinishTime();
            vehicleStatisticDb.MaxSpeed = vehicle.GetMaxSpeed();
            vehicleStatisticDb.RepairTime = vehicle.GetRepairTime();
            vehicleStatisticDb.LightMalfunctionChance = vehicle.GetLightMalfunctionChance() + "%";
            vehicleStatisticDb.HeavyMalfunctionChance = vehicle.GetHeavyMalfunctionChance() + "%";
            return vehicleStatisticDb;
        }

        internal static MalfunctionDb ModelEntityToDbMalfunctions(Malfunction malf)
        {           
            MalfunctionDb malfanctionDb = new MalfunctionDb();
            malfanctionDb.TimeSinceMalfunction = malf.TimeSinceMalfunction;
            malfanctionDb.Type = malf.Type.ToString();
            malfanctionDb.IsFixed = malf.IsFixed;
            return malfanctionDb;
        }

        internal static RaceStatusDtoModel DbToEntityModelRaceStatus(RaceStatusDtoModelDb statusDtoModelDb)
        {
            RaceStatusDtoModel raceStatus = new RaceStatusDtoModel();
            raceStatus.RaceStatus = statusDtoModelDb.RaceStatus;
            raceStatus.GrouByVehicleStatus = statusDtoModelDb.GrouByVehicleStatus;
            raceStatus.GrouByVehicleType = statusDtoModelDb.GrouByVehicleType;
            return raceStatus;
        }

        internal static VehicleStatisticDtoModel DbToEntityModelVehicleStatus (VehicleStatisticDtoDb vehicleStatisticDtoDb)
        {
            VehicleStatisticDtoModel raceStatusDto = new VehicleStatisticDtoModel();
            raceStatusDto.Distance = vehicleStatisticDtoDb.Distance;
            raceStatusDto.FinishingTime = vehicleStatisticDtoDb.FinishingTime;
            raceStatusDto.Status = vehicleStatisticDtoDb.Status;
            return raceStatusDto;
        }

        internal static Malfunction DbToModelEntityMalfunctions(MalfunctionDb malfDb)
        {
            Malfunction malfanction = new Malfunction();
            malfanction.SetTimeSinceMalfunction(malfDb.TimeSinceMalfunction);
            malfanction.SetType(MalfunctionTypeEnumerationConversion(malfDb.Type));
            malfanction.SetIsFixed(malfDb.IsFixed);
            return malfanction;
        }


        internal static Enumerations.VehicleType VehicleTypeEnumerationConversion(string type)
        {
            Enumerations.VehicleType vehicleType = (Enumerations.VehicleType)System.Enum.Parse(typeof(Enumerations.VehicleType), type);
            return vehicleType;

        }

        internal static Enumerations.VehicleStatus VehicleStatusEnumerationConversion(string status)
        {
            Enumerations.VehicleStatus vehicleStatus = (Enumerations.VehicleStatus)System.Enum.Parse(typeof(Enumerations.VehicleStatus), status);
            return vehicleStatus;

        }

        internal static Enumerations.VehicleSubType VehicleSubTypeEnumerationConversion(string subType)
        {
            Enumerations.VehicleSubType vehicleSubType = (Enumerations.VehicleSubType)System.Enum.Parse(typeof(Enumerations.VehicleSubType), subType);
            return vehicleSubType;
        }

        internal static Enumerations.RaceStatus RaceStatuseEnumerationConversion(string status)
        {
            Enumerations.RaceStatus raceStatus = (Enumerations.RaceStatus)System.Enum.Parse(typeof(Enumerations.RaceStatus), status);
            return raceStatus;
        }

        internal static Enumerations.MalfunctionType MalfunctionTypeEnumerationConversion(string type)
        {
            Enumerations.MalfunctionType malfunctionType = (Enumerations.MalfunctionType)System.Enum.Parse(typeof(Enumerations.MalfunctionType), type);
            return malfunctionType;

        }
    }
}
