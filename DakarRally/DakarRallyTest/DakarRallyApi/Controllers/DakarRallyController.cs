using DakarRallyApi.Dtos;
using DakarRallyApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DakarRallyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DakarRallyController : ControllerBase
    {
        private readonly IDakarRallyService dakarRallyService;

        public DakarRallyController(IDakarRallyService dakarRallyService)
        {
            this.dakarRallyService = dakarRallyService;
        }

        [HttpPost]
        [Route("CreateRace/{year}")]
        public async Task<IActionResult> CreateRace(int year)
        {
            var response = await dakarRallyService.CreateRace(year);
            if (response.StatusCode == StatusCodes.Status500InternalServerError)
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            else if (response.StatusCode == StatusCodes.Status400BadRequest)
                return BadRequest(response);
            return CreatedAtAction("CreateRace", response);
        }

        [HttpPost]
        [Route("AddVehicle")]
        public async Task<IActionResult> AddVehicle(AddVehicleDto request)
        {
            var response = await dakarRallyService.AddVehicle(request);
            if (response.StatusCode == StatusCodes.Status500InternalServerError)
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            else if (response.StatusCode == StatusCodes.Status400BadRequest)
                return BadRequest(response);
            return CreatedAtAction("AddVehicle", response);
        }

        [HttpPut]
        [Route("UpdateVehicle")]
        public async Task<IActionResult> UpdateVehicle(UpdateVehicleDto request)
        {
            var response = await dakarRallyService.UpdateVehicle(request);
            if (response.StatusCode == StatusCodes.Status404NotFound)
                return NotFound(response);
            else if (response.StatusCode == StatusCodes.Status400BadRequest)
                return BadRequest(response);
            else if (response.StatusCode == StatusCodes.Status500InternalServerError)
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            return Ok(response);
        }

        [HttpDelete]
        [Route("RemoveVehicle/{id}")]
        public async Task<IActionResult> RemoveVehicle(int id)
        {
            var response = await dakarRallyService.RemoveVehicle(id);
            if (response.StatusCode != StatusCodes.Status404NotFound)
                return NotFound(response);
            else if (response.StatusCode == StatusCodes.Status400BadRequest)
                return BadRequest(response);
            else if (response.StatusCode == StatusCodes.Status500InternalServerError)
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            return Ok(response);
        }

        [HttpGet]
        [Route("RunRace")]
        public IActionResult RunRaces()
        {
            dakarRallyService.RunRace();
            return Ok("Dakar Race has been started!");
        }

        [HttpGet]
        [Route("GetLeaderboard/{vehicleType?}")]
        public async Task<IActionResult> GetLeaderboard(string vehicleType = "")
        {
            var response = await dakarRallyService.GetLeaderboard(vehicleType);
            if (response.StatusCode != StatusCodes.Status404NotFound)
                return NotFound(response);
            if (response.StatusCode == StatusCodes.Status500InternalServerError)
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetRaceStatus/{id}")]
        public async Task<IActionResult> GetRaceStatus(int id)
        {
            var response = await dakarRallyService.GetRaceStatus(id);
            if (response.StatusCode != StatusCodes.Status404NotFound)
                return NotFound(response);
            if (response.StatusCode == StatusCodes.Status500InternalServerError)
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetVehicleStatus/{id}")]
        public async Task<IActionResult> GetVehicleStatus(int id)
        {
            var response = await dakarRallyService.GetVehicleStatus(id);
            if (response.StatusCode != StatusCodes.Status404NotFound)
                return NotFound(response);
            if (response.StatusCode == StatusCodes.Status500InternalServerError)
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            return Ok(response);
        }

        

    }
    
}
