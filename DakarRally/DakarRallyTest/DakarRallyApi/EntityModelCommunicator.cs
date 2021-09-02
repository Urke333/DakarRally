using DakarRally;
using DakarRallyApi.Dtos;
using System.Collections.Generic;

namespace DakarRallyApi
{
    public class EntityModelCommunicator
    {
        private DakarRallyService dakarRallyService;

        public EntityModelCommunicator() 
        {
            dakarRallyService = new DakarRallyService();
        }
   
        public List<ResponseRaceDto> CreateRace(int raceYear)
        {
            var responseRaceListModel = dakarRallyService.CreateRace(raceYear);
            return Converter.EntityModelToResponseRaces(responseRaceListModel);
        }

        public List<ResponseVehicleDto> AddVehicle(AddVehicleDto addVehicleRequest)
        {
            var vehicleRequestModel = Converter.AddVehicleRequestToEntityModel(addVehicleRequest);
            var responseVehicleListModel = dakarRallyService.AddVehicle(vehicleRequestModel);
            var responseVehicleApi = Converter.EntityModelToResponseVehicles(responseVehicleListModel);
            return responseVehicleApi;

        }

        public List<ResponseVehicleDto> UpdatedVehicle(UpdateVehicleDto updateVehicleRequest)
        {
            var vehicleRequestModel = Converter.UpdateVehicleRequestToEntityModel(updateVehicleRequest);
            var responseVehicleListModel = dakarRallyService.UpdateVehicle(vehicleRequestModel);
            var responseVehicleApi = Converter.EntityModelToResponseVehicles(responseVehicleListModel);
            return responseVehicleApi;
        }

        public List<ResponseVehicleDto> RemoveVehicle(int id)
        {
            var responseVehicleListModel = dakarRallyService.RemoveVehicle(id);
            var responseVehicleApi = Converter.EntityModelToResponseVehicles(responseVehicleListModel);
            return responseVehicleApi;
        }

        public List<ResponseLeaderboardDto> GetLeaderboard(string vehicleType)
        {
            var responseVehicleListModel = dakarRallyService.GetLeaderboard(vehicleType);
            var responseVehicleApi = Converter.EntityModelToResponseLeaderboard(responseVehicleListModel);
            return responseVehicleApi;
        }

        public ResponseRaceStatusDto GetRaceStatus(int id)
        {
            var responseRaceStatusModel = dakarRallyService.GetRaceStatus(id);
            var responseRaceStatusApi = Converter.EntityModelToResponseRaceStatus(responseRaceStatusModel);
            return responseRaceStatusApi;
        }

        public ResponseVehicleStatisticDto GetVehicleStatus(int id)
        {
            List<MalfunctionDto> malfunctionDtos = new List<MalfunctionDto>();
            var responseVehicleStatusModel = dakarRallyService.GetVehicleStatus(id);
            var responseVehicleStatusApi = Converter.EntityModelToResponseVehicleStatistic(responseVehicleStatusModel);
            foreach (var malf in responseVehicleStatusModel.Malfanctions)
            {
                malfunctionDtos.Add(Converter.EntityModelToMalfunctionApi(malf));
            }
            responseVehicleStatusApi.Malfanctions = malfunctionDtos;
            return responseVehicleStatusApi;
        }

        public void RunRace()
        {
            dakarRallyService.RunRace();
        }
    }
}
