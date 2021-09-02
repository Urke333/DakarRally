using DakarRallyDb.Data;
using DakarRallyDb.Dtos;
using DakarRallyDb.Helpers;
using DakarRallyDb.Interfaces;
using DakarRallyDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DakarRallyDb.Helpers.Enumerations;

namespace DakarRallyDb
{
    public class DakarRallyDbAccess : IDakarRallyDbAccess
    {
        private DataContext context;

        public DakarRallyDbAccess()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseInMemoryDatabase("DakarRallyDb");
            this.context = new DataContext(optionsBuilder.Options);
        }

        public async Task<List<Race>> CreateRace(Race race)
        {
            if (await context.Races.AnyAsync(r => r.Year == race.Year))
                throw new InvalidOperationException("Dakar rally with the same year already exists.");
            await context.Races.AddAsync(race);
            await context.SaveChangesAsync();
            return context.Races.OrderBy(r=> r.Year).ToList();
        }
        public async Task UpdateRace(Race race)
        {
            var currRace = await context.Races.FirstOrDefaultAsync(r => r.Year == race.Year);
            currRace.Status = race.Status;
            context.Races.Update(currRace);
            await context.SaveChangesAsync();
        }

        public async Task<List<Vehicle>> AddVehicle(Vehicle vehicle)
        {
            vehicle.Race = await context.Races.FirstOrDefaultAsync(r => r.Status == Enumerations.RaceStatus.Pending.ToString());
            if (vehicle.Race == null)
                throw new InvalidOperationException("Pending race does not exist.");
            
            await context.Vehicles.AddAsync(vehicle);
            await context.SaveChangesAsync();
            return context.Vehicles.OrderBy(v=>vehicle.Id).ToList();
        }

        public async Task<List<Vehicle>> UpdateVehicle(Vehicle updatedVehicle)
        {
            var pendingRace = await context.Races.AnyAsync(r => r.Status == RaceStatus.Pending.ToString());
            if (pendingRace == null)
                throw new InvalidOperationException("Pending race does not exist.");

            var vehicle = await context.Vehicles.Include(v => v.Race)
                                                    .FirstOrDefaultAsync(v => v.Id == updatedVehicle.Id);

            if(vehicle == null)
                throw new MissingMemberException($"Vehicle with ID : {updatedVehicle.Id} does not exist.");   

            if(!Validation.CheckIfTypeDoesNotExist(updatedVehicle))
                throw new InvalidOperationException("Updated vehicle type does not exist");

            if(!Validation.CheckIfSubTypeDoesNotExist(updatedVehicle))
                throw new InvalidOperationException("Updated vehicle sub type does not exist");

            vehicle.VehicleType = updatedVehicle.VehicleType;
            vehicle.TeamName = updatedVehicle.TeamName;
            vehicle.Model = updatedVehicle.Model;
            vehicle.ManufacturingDate = updatedVehicle.ManufacturingDate;
            vehicle.SubType = updatedVehicle.SubType;

            context.Vehicles.Update(vehicle);
            await context.SaveChangesAsync();
            return context.Vehicles.OrderBy(v => vehicle.Id).ToList();
        }

        public async Task<List<Vehicle>> RemoveVehicle(int id)
        {
            var pendingRace = await context.Races.AnyAsync(r => r.Status == RaceStatus.Pending.ToString());
            if (pendingRace == null)
                throw new InvalidOperationException("Pending race does not exist.");

            var vehicle = await context.Vehicles.Include(v => v.Race).FirstOrDefaultAsync(v => v.Id == id);
            if (vehicle == null)
                throw new MissingMemberException($"Vehicle with ID : {id} does not exist.");

            context.Vehicles.Remove(vehicle);
            await context.SaveChangesAsync();
            return context .Vehicles.OrderBy(v => vehicle.Id).ToList();
        }

        public async Task UpdateVehicleDuringRace(Vehicle vehicle, VehicleStatistic vehicleStatistic)
        {
            var veh = await context.Vehicles.FirstOrDefaultAsync(v => v.Id == vehicle.Id);
            veh.VehicleStatistic = vehicleStatistic;
            veh.Status = vehicle.Status;
            await context.SaveChangesAsync();
        }

        public async Task<Race> GetPendingRace()
        {
            var pendingRace = await context.Races.Include(r => r.Vehicles).ThenInclude(v=>v.VehicleStatistic).FirstOrDefaultAsync(r => r.Status == Enumerations.RaceStatus.Pending.ToString());
            if (pendingRace == null)
                throw new InvalidOperationException("Pending race does not exist.");
            return pendingRace;
        }

        public async Task<List<Vehicle>> GetLeaderboard(string vehicleType)
        {
            var runningRace = await context.Races.Include(r => r.Vehicles.Where(v => String.IsNullOrEmpty(vehicleType) || v.VehicleType.Equals(vehicleType, StringComparison.InvariantCultureIgnoreCase)))
                                                                        .ThenInclude(v => v.VehicleStatistic)
                                                                        .FirstOrDefaultAsync(r => r.Status == Enumerations.RaceStatus.Running.ToString());       
            if (runningRace == null)
                throw new InvalidOperationException("Running race does not exist.");
            var orderedList = runningRace.Vehicles.OrderByDescending(v => v.VehicleStatistic.Distance).ToList();
            return orderedList;
        }

        public async Task<RaceStatusDto> GetRaceStatus(int id)
        {
            RaceStatusDto raceStatus = new RaceStatusDto();
            var race = await context.Races.Include(r => r.Vehicles).FirstOrDefaultAsync(r => r.Year == id);
            if (race == null)
                throw new InvalidOperationException($"Race from {id} does not exist.");

            var groupedByVehicleStatusVehicles = race.Vehicles.GroupBy(v => v.Status);
            Dictionary<string, int> vehicleByStatus = new Dictionary<string, int>();
            groupedByVehicleStatusVehicles.ToList().ForEach(o => vehicleByStatus.Add(o.Key, o.Count()));

            var groupedByTypeVehicles = race.Vehicles.GroupBy(v => v.VehicleType);
            Dictionary<string, int> vehicleByType = new Dictionary<string, int>();
            groupedByTypeVehicles.ToList().ForEach(o => vehicleByType.Add(o.Key, o.Count()));

            raceStatus.RaceStatus = race.Status;
            raceStatus.GrouByVehicleStatus = vehicleByStatus;
            raceStatus.GrouByVehicleType = vehicleByType;

            return raceStatus;
        }

        public async Task<VehicleStatisticDto> GetVehicleStatus(int id)
        {
            VehicleStatisticDto vehicleStatisticDto = new VehicleStatisticDto();
            var vehicle = await context.Vehicles.Include(v => v.VehicleStatistic)
                                                .ThenInclude(v=>v.Malfanctions)
                                                .FirstOrDefaultAsync(v => v.Id == id);
            if (vehicle == null)
                throw new InvalidOperationException($"Vehicle with ID:{id} does not exist.");
            vehicleStatisticDto.Distance = vehicle.VehicleStatistic.Distance;
            vehicleStatisticDto.FinishingTime = vehicle.VehicleStatistic.FinishingTime;
            vehicleStatisticDto.Malfanctions = vehicle.VehicleStatistic.Malfanctions.ToList();
            vehicleStatisticDto.Status = vehicle.Status;
            return vehicleStatisticDto;
        }
    }
}
