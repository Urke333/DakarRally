using DakarRally.Dtos;
using DakarRally.Models;
using DakarRallyDb;
using System.Collections.Generic;
using MalfunctionDb = DakarRallyDb.Models.Malfunction;

namespace DakarRally
{
    public class DbCommunicator
    {
        private DakarRallyDbAccess dakarRallyDbAccess;

        public DbCommunicator()
        {
            dakarRallyDbAccess = new DakarRallyDbAccess();
        }
        public List<Race> CreateRace(Race race)
        {
            List<Race> raceListModel = new List<Race>();
            var raceDb = Converter.ModelEntityToDbRace(race);
            var raceListDb = dakarRallyDbAccess.CreateRace(raceDb).Result;
            foreach(var r in raceListDb)
                raceListModel.Add(Converter.DbToModelEntityRace(r));
            return raceListModel;
        }

        public List<Vehicle> AddVehicle(Vehicle vehicle)
        {
            List<Vehicle> vehicleListModel = new List<Vehicle>();
            var vehicleDb = Converter.ModelEntityToDbVehicle(vehicle);
            var vehicleStatisticDb = Converter.ModelEntityToDbVehicleStatistic(vehicle);
            vehicleDb.VehicleStatistic = vehicleStatisticDb;
            var vehicleListDb = dakarRallyDbAccess.AddVehicle(vehicleDb).Result;
            foreach (var v in vehicleListDb)
                vehicleListModel.Add(Converter.DbToModelEntityVehicle(v));
            return vehicleListModel;
        }

        public List<Vehicle> UpdateVehicle(Vehicle updateVehicle)
        {
            List<Vehicle> vehicleListModel = new List<Vehicle>();
            var updateVehicleDb = Converter.ModelEntityToDbVehicle(updateVehicle);
            var vehicleListDb = dakarRallyDbAccess.UpdateVehicle(updateVehicleDb).Result;
            foreach (var v in vehicleListDb)
                vehicleListModel.Add(Converter.DbToModelEntityVehicle(v));
            return vehicleListModel;
        }

        internal List<Vehicle> RemoveVehicle(int id)
        {
            List<Vehicle> vehicleListModel = new List<Vehicle>();
            var vehicleListDb = dakarRallyDbAccess.RemoveVehicle(id).Result;
            foreach (var v in vehicleListDb)
                vehicleListModel.Add(Converter.DbToModelEntityVehicle(v));
            return vehicleListModel;
        }

        internal void UpdateRace(Race race)
        {
            var raceDb = Converter.ModelEntityToDbRace(race);
            dakarRallyDbAccess.UpdateRace(raceDb);
        }

        internal Race FindPendingRace()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            var pendingRace = dakarRallyDbAccess.GetPendingRace().Result;
            var raceModel = Converter.DbToModelEntityRace(pendingRace);
            foreach (var v in pendingRace.Vehicles)
            {
                var vehicleVehicleTypeValues = Converter.DbToModelEntityVehicleTypeValues(v);
                var vehicle = Converter.DbToModelEntityVehicle(v);
                vehicle.SetVehicleTypeValues(vehicleVehicleTypeValues);
                vehicles.Add(vehicle);
                
            }
            raceModel.SetVehicleList(vehicles);

            return raceModel;
        }

        internal void UpdateVehicleDuringRace(Vehicle vehicle)
        {
            List<MalfunctionDb> malfanctionListDb = new List<MalfunctionDb>();
            var vehicleDb = Converter.ModelEntityToDbVehicle(vehicle);
            var vehicleStatisticDb = Converter.ModelEntityToDbVehicleStatistic(vehicle);          
            foreach (var malf in vehicle.GetMalfunctions())
            {
                var malfDb = Converter.ModelEntityToDbMalfunctions(malf);
                malfanctionListDb.Add(malfDb);                
            }
            vehicleStatisticDb.Malfanctions = malfanctionListDb;
            vehicleDb.VehicleStatistic = vehicleStatisticDb;
            dakarRallyDbAccess.UpdateVehicleDuringRace(vehicleDb, vehicleStatisticDb);
        }

        internal List<Vehicle>GetLeaderboard(string vehicleType)
        {
            List<Vehicle> vehicleListModel = new List<Vehicle>();
            var vehicleListDb = dakarRallyDbAccess.GetLeaderboard(vehicleType).Result;
            foreach (var v in vehicleListDb)
            {
                var vehicleModel = Converter.DbToModelEntityVehicle(v);
                vehicleModel.SetDistance(v.VehicleStatistic.Distance);
                vehicleListModel.Add(vehicleModel);
            }
            return vehicleListModel;
        }

        internal RaceStatusDto GetRaceStatus (int id)
        {
            var raceStatusDtoDb = dakarRallyDbAccess.GetRaceStatus(id).Result;
            var raceStatusDtoModel = Converter.DbToEntityModelRaceStatus(raceStatusDtoDb);
            return raceStatusDtoModel;
        }

        internal VehicleStatisticDto GetVehicleStatus(int id)
        {
            List<Malfunction> malfunctions = new List<Malfunction>();
            var vehicleStatusDt = dakarRallyDbAccess.GetVehicleStatus(id).Result;
            var vehicleStatusDtoModel = Converter.DbToEntityModelVehicleStatus(vehicleStatusDt);
            foreach (var malf in vehicleStatusDt.Malfanctions)
            {
                malfunctions.Add(Converter.DbToModelEntityMalfunctions(malf));
            }
            vehicleStatusDtoModel.Malfanctions = malfunctions;
            return vehicleStatusDtoModel;
        }
    }
}
