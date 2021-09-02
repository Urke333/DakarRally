using DakarRallyApi.Dtos;
using DakarRallyApi.Interfaces;
using DakarRallyApi.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DakarRallyApi.Services
{
    public class DakarRallyService : IDakarRallyService
    {
        private EntityModelCommunicator modelCommunicator;

        public DakarRallyService()
        {
            this.modelCommunicator = new EntityModelCommunicator();
        }

        public async Task<ServiceResponse<List<ResponseRaceDto>>> CreateRace(int year)
        {
            ServiceResponse<List<ResponseRaceDto>> response = new ServiceResponse<List<ResponseRaceDto>>();
            try
            {
                var responseRaces = modelCommunicator.CreateRace(year);

                response.Data = responseRaces;
                response.Success = true;
                response.StatusCode = StatusCodes.Status201Created;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.GetType() == typeof(InvalidOperationException))
                {
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    response.Data = null;
                    response.Success = false;
                    response.Message = ex.Message;
                }
                else
                {
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.Data = null;
                    response.Success = false;
                    response.Message = ex.Message;
                }
            }
            return response;
        }

        public async Task<ServiceResponse<List<ResponseVehicleDto>>> AddVehicle(AddVehicleDto addVehicleRequest)
        {
            ServiceResponse<List<ResponseVehicleDto>> response = new ServiceResponse<List<ResponseVehicleDto>>();
            try
            {
                var responseVehicles = modelCommunicator.AddVehicle(addVehicleRequest);

                response.Data = responseVehicles;
                response.Success = true;
                response.StatusCode = StatusCodes.Status201Created;
            }
            catch (InvalidOperationException ex)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.GetType() == typeof(InvalidOperationException))
                {
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    response.Data = null;
                    response.Success = false;
                    response.Message = ex.Message;
                }
                else
                {
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.Data = null;
                    response.Success = false;
                    response.Message = ex.Message;
                }
            }
            return response;
        }

        public async Task<ServiceResponse<List<ResponseVehicleDto>>> UpdateVehicle(UpdateVehicleDto updateVehicleRequest)
        {
            ServiceResponse<List<ResponseVehicleDto>> response = new ServiceResponse<List<ResponseVehicleDto>>();
            try
            {
                var responseVehicles = modelCommunicator.UpdatedVehicle(updateVehicleRequest);

                response.Data = responseVehicles;
                response.Success = true;
                response.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.GetType() == typeof(MissingMemberException))
                {
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.Data = null;
                    response.Success = false;
                    response.Message = ex.Message;
                }
                else if (ex.InnerException.GetType() == typeof(InvalidOperationException))
                {
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    response.Data = null;
                    response.Success = false;
                    response.Message = ex.Message;
                }
                else
                {
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.Success = false;
                    response.Message = ex.Message;
                }
            }
            return response;
        }

        public async Task<ServiceResponse<List<ResponseVehicleDto>>> RemoveVehicle(int id)
        {
            ServiceResponse<List<ResponseVehicleDto>> response = new ServiceResponse<List<ResponseVehicleDto>>();
            try
            {
                var responseVehicles = modelCommunicator.RemoveVehicle(id);

                response.Data = responseVehicles;
                response.Success = true;
                response.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.GetType() == typeof(MissingMemberException))
                {
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.Data = null;
                    response.Success = false;
                    response.Message = ex.Message;
                }
                else if (ex.InnerException.GetType() == typeof(InvalidOperationException))
                {
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    response.Data = null;
                    response.Success = false;
                    response.Message = ex.Message;
                }
                else
                {
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.Success = false;
                    response.Message = ex.Message;
                }
            }
            return response;
        }

        public async Task<ServiceResponse<List<ResponseLeaderboardDto>>> GetLeaderboard(string vehicleType)
        {
            ServiceResponse<List<ResponseLeaderboardDto>> response = new ServiceResponse<List<ResponseLeaderboardDto>>();
            try
            {
                var responseVehicles = modelCommunicator.GetLeaderboard(vehicleType);

                response.Data = responseVehicles;
                response.Success = true;
                response.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.GetType() == typeof(MissingMemberException))
                {
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.Data = null;
                    response.Success = false;
                    response.Message = ex.Message;
                }
                else
                {
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.Success = false;
                    response.Message = ex.Message;
                }
            }
            return response;
        }

        public async Task<ServiceResponse<ResponseRaceStatusDto>> GetRaceStatus(int id)
        {
            ServiceResponse<ResponseRaceStatusDto> response = new ServiceResponse<ResponseRaceStatusDto>();
            try
            {
                var responseRaceStatus = modelCommunicator.GetRaceStatus(id);

                response.Data = responseRaceStatus;
                response.Success = true;
                response.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception ex)
            {               
                if (ex.InnerException.GetType() == typeof(MissingMemberException))
                {
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.Data = null;
                    response.Success = false;
                    response.Message = ex.Message;
                }
                else
                {
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.Success = false;
                    response.Message = ex.Message;
                }
            }
            return response;
        }

        public async Task<ServiceResponse<ResponseVehicleStatisticDto>> GetVehicleStatus(int id)
        {
            ServiceResponse<ResponseVehicleStatisticDto> response = new ServiceResponse<ResponseVehicleStatisticDto>();
            try
            {
                var responseVehicleStatus = modelCommunicator.GetVehicleStatus(id);

                response.Data = responseVehicleStatus;
                response.Success = true;
                response.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.GetType() == typeof(MissingMemberException))
                {
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.Data = null;
                    response.Success = false;
                    response.Message = ex.Message;
                }
                else
                {
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.Success = false;
                    response.Message = ex.Message;
                }
            }
            return response;
        }



        public void RunRace()
        {
            modelCommunicator.RunRace();
        }
    }
}
