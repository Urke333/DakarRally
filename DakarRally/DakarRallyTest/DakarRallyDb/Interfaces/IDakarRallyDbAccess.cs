using DakarRallyDb.Dtos;
using DakarRallyDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DakarRallyDb.Helpers.Enumerations;

namespace DakarRallyDb.Interfaces
{
    public interface IDakarRallyDbAccess
    {
        Task<List<Race>> CreateRace(Race race);
        Task UpdateRace(Race race);
        Task<List<Vehicle>> AddVehicle(Vehicle vehicle);
        Task<List<Vehicle>> UpdateVehicle(Vehicle updatedVehicle);
        Task<List<Vehicle>> RemoveVehicle(int id);
        Task<List<Vehicle>> GetLeaderboard(string vehicleType);
        Task UpdateVehicleDuringRace(Vehicle vehicle, VehicleStatistic vehicleStatistic);
        Task<VehicleStatisticDto> GetVehicleStatus(int id);

    }
}
