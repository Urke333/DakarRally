using DakarRally.Enumerations;
using DakarRallyApi.Dtos;
using DakarRallyApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle = DakarRally.Models.Vehicle;
using Race = DakarRally.Models.Race;
using RaceStatusDtoModel = DakarRally.Dtos.RaceStatusDto;
using ResponseVehicleStatisticDtoModel = DakarRally.Dtos.VehicleStatisticDto;
using DakarRally.Models;

namespace DakarRallyApi
{
    internal static class Converter
    {
        internal static Vehicle AddVehicleRequestToEntityModel(AddVehicleDto request)
        {
            Vehicle vehicle = new Vehicle();
            vehicle.SetTeamName(request.TeamName);
            vehicle.SetModel(request.Model);
            vehicle.SetManufacturingDate(request.ManufacturingDate);
            var vehicleType = VehicleTypeEnumerationConversion(request.VehicleType);
            var vehicleSubType = VehicleSubTypeEnumerationConversion(request.SubType);
            vehicle.SetVehicleType(vehicleType);
            vehicle.SetVehicleSubType(vehicleSubType);
            return vehicle;
        }

        internal static Vehicle UpdateVehicleRequestToEntityModel(UpdateVehicleDto request)
        {
            Vehicle vehicle = new Vehicle();
            vehicle.SetVehicleId(request.Id);
            vehicle.SetTeamName(request.TeamName);
            vehicle.SetModel(request.Model);
            vehicle.SetManufacturingDate(request.ManufacturingDate);
            var vehicleType = VehicleTypeEnumerationConversion(request.VehicleType);
            var vehicleSubType = VehicleSubTypeEnumerationConversion(request.SubType);
            vehicle.SetVehicleType(vehicleType);
            vehicle.SetVehicleSubType(vehicleSubType);
            return vehicle;
        }

        internal static ResponseVehicleDto EntityModelToResponseVehicle(Vehicle vehicle)
        {
            ResponseVehicleDto response = new ResponseVehicleDto();
            response.VehicleType = vehicle.GetVehicleType().ToString();
            response.TeamName = vehicle.TeamName;
            response.Model = vehicle.Model;
            response.ManufacturingDate = vehicle.ManufacturingDate;
            response.SubType = vehicle.GetVehicleSubType().ToString();
            return response;
        }

        internal static List<ResponseVehicleDto> EntityModelToResponseVehicles(List<Vehicle> vehicles)
        {
            List<ResponseVehicleDto> responseVehicleDtos = new List<ResponseVehicleDto>();
            foreach(var veh in vehicles)
            {
                ResponseVehicleDto responseVeh = new ResponseVehicleDto();
                responseVeh.Id = veh.ID;
                responseVeh.VehicleType = veh.GetVehicleType().ToString();
                responseVeh.TeamName = veh.TeamName;
                responseVeh.Model = veh.Model;
                responseVeh.ManufacturingDate = veh.ManufacturingDate;
                responseVeh.SubType = veh.GetVehicleSubType().ToString();
                responseVehicleDtos.Add(responseVeh);
            }    
            return responseVehicleDtos;
        }

        internal static List<ResponseLeaderboardDto> EntityModelToResponseLeaderboard(List<Vehicle> vehicles)
        {
            List<ResponseLeaderboardDto> responseLeaderboard = new List<ResponseLeaderboardDto>();
            foreach (var veh in vehicles)
            {
                ResponseLeaderboardDto responseVeh = new ResponseLeaderboardDto();
                responseVeh.VehicleType = veh.GetVehicleType().ToString();
                responseVeh.TeamName = veh.TeamName;
                responseVeh.Model = veh.Model;
                responseVeh.ManufacturingDate = veh.ManufacturingDate;
                responseVeh.SubType = veh.GetVehicleSubType().ToString();
                responseVeh.Distance = veh.GetDistance();

                responseLeaderboard.Add(responseVeh);
            }
            return responseLeaderboard;
        }

        internal static List<ResponseRaceDto> EntityModelToResponseRaces(List<Race> races)
        {
            List<ResponseRaceDto> responseRaceDtos = new List<ResponseRaceDto>();
            foreach (var r in races)
            {
                ResponseRaceDto responseRace = new ResponseRaceDto();
                responseRace.Year = r.Year;
                responseRace.Status = r.Status.ToString();
                responseRaceDtos.Add(responseRace);
            }
            return responseRaceDtos;
        }

        internal static ResponseRaceDto EntityModelToResponseRace(Race race)
        {
            ResponseRaceDto response = new ResponseRaceDto();
            response.Year = race.Year;
            response.Status = race.Status.ToString();
            return response;
        }

        internal static ResponseRaceStatusDto EntityModelToResponseRaceStatus(RaceStatusDtoModel statusDtoModel)
        {
            ResponseRaceStatusDto response = new ResponseRaceStatusDto();
            response.RaceStatus = statusDtoModel.RaceStatus;
            response.GrouByVehicleStatus = statusDtoModel.GrouByVehicleStatus;
            response.GrouByVehicleType = statusDtoModel.GrouByVehicleType;
            return response;
        }

        internal static ResponseVehicleStatisticDto EntityModelToResponseVehicleStatistic(ResponseVehicleStatisticDtoModel vehicleStatisticDtoModel)
        {
            ResponseVehicleStatisticDto response = new ResponseVehicleStatisticDto();
            response.Distance = vehicleStatisticDtoModel.Distance;
            response.FinishingTime = vehicleStatisticDtoModel.FinishingTime;
            response.Status = vehicleStatisticDtoModel.Status;
            return response;
        }

        internal static MalfunctionDto EntityModelToMalfunctionApi(Malfunction malf)
        {
            MalfunctionDto malfanction = new MalfunctionDto();
            malfanction.TimeSinceMalfunction = malf.TimeSinceMalfunction;
            malfanction.Type = malf.Type.ToString();
            malfanction.IsFixed = malf.IsFixed;
            return malfanction;
        }


        internal static VehicleType VehicleTypeEnumerationConversion(string type)
        {
            VehicleType vehicleType;
            if (!Enum.TryParse<VehicleType>(type, true, out vehicleType))
                return vehicleType = default;
            return vehicleType = (VehicleType)System.Enum.Parse(typeof(VehicleType), type, true);

        }

        internal static VehicleSubType VehicleSubTypeEnumerationConversion(string subType)
        {
            VehicleSubType vehicleSubType;
            if (subType == "")
                return VehicleSubType.Truck;
            if (!Enum.TryParse<VehicleSubType>(subType, true, out vehicleSubType))
                return vehicleSubType = default;
            return vehicleSubType = (VehicleSubType)System.Enum.Parse(typeof(VehicleSubType), subType, true);
        }
    }
}
