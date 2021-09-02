using DakarRallyApi.Dtos;
using DakarRallyApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DakarRallyApi.Interfaces
{
    public interface IDakarRallyService
    {
        Task<ServiceResponse<List<ResponseRaceDto>>> CreateRace(int year);
        Task<ServiceResponse<List<ResponseVehicleDto>>> AddVehicle(AddVehicleDto request);
        Task<ServiceResponse<List<ResponseVehicleDto>>> UpdateVehicle(UpdateVehicleDto requestComment);
        Task<ServiceResponse<List<ResponseVehicleDto>>> RemoveVehicle(int id);
        Task<ServiceResponse<List<ResponseLeaderboardDto>>> GetLeaderboard(string vehicleType);
        Task<ServiceResponse<ResponseRaceStatusDto>> GetRaceStatus(int id);
        Task<ServiceResponse<ResponseVehicleStatisticDto>> GetVehicleStatus(int id);
        void RunRace();

    }
}
