using Microsoft.AspNetCore.Mvc;
using CarSimulator.Models;
using CarSimulator.Services;
using System;
using System.Collections.Concurrent;

namespace CarSimulatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        private string GenerateSessionId()
        {
            return Guid.NewGuid().ToString(); 
        }

        [HttpPost("add-car")]
        public ActionResult AddCar()
        {
            try
            {
                string currentSessionId = GenerateSessionId();
                _carService.AddCar(currentSessionId);
                string type = _carService.GetCarType();
                return Ok(new { 
                    Message = $"Car added and selected.", 
                    SessionId = currentSessionId,
                    Type = type,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = $"Error adding a car: {ex.Message}" });;
            }
           
        }

        [HttpPost("select-car")]
        public ActionResult SelectCar([FromQuery] string sessionId)
        {
            try
            {
                string newSessionId = _carService.selectCar(sessionId);
                if (sessionId == newSessionId) {
                    string type = _carService.GetCarType();
                    return Ok(new { 
                        Message = $"Car in the session id: {sessionId} selected.",
                        SessionId = sessionId,
                        Type = type,
                     });
                } else {
                     return Ok(new { Message = $"No car was found with the session id: {sessionId}." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = $"Error selecting car: {ex.Message}" });
            }
        }

        [HttpGet("get-type")]
        public ActionResult<string> GetCarType()
        {
            try
            {
                return Ok(_carService.GetCarType());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = $"Error gettin car type: {ex.Message}" });
            }
            
        }

        [HttpPost("accelerate")]
        public ActionResult Accelerate()
        {
            try
            {
                _carService.Accelerate();
                return Ok(new { Speed = _carService.GetSpeed() });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = $"Error accelerating: {ex.Message}" });
            }
        }

        [HttpPost("brake")]
        public ActionResult Brake()
        {
            try
            {
                _carService.Brake();
                return Ok(new { Speed = _carService.GetSpeed() });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = $"Error braking: {ex.Message}" });
            }
        }

        [HttpPost("steer")]
        public ActionResult Steer([FromQuery] string direction, [FromQuery] int degrees)
        {
            try
            {
                string directionInLower = direction.ToLower();
                if (direction != "left" && direction != "right") {
                     return Ok(new { Message = $"Invalid direction" });
                }
                _carService.Steer(direction, degrees);
                return Ok(new { Direction = _carService.GetDirection() });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = $"Error steering: {ex.Message}" });
            }
        }

        [HttpGet("get-speed")]
        public ActionResult<int> GetSpeed()
        {
            try
            {
                return Ok(_carService.GetSpeed());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = $"Error getting speed: {ex.Message}" });
            }
            
        }

        [HttpGet("get-direction")]
        public ActionResult<int> GetDirection()
        {
            try
            {
                return Ok(_carService.GetDirection());
            }
            catch (Exception ex)
            {
               return BadRequest(new { Error = $"Error getting direction: {ex.Message}" });
            }
           
        }

        [HttpPost("fill-with")]
        public ActionResult FillWith([FromQuery] string fuelType)
        {
            try
            {
                string fuelTypeInLower = fuelType.ToLower();
                if (!Enum.TryParse<FuelType>(fuelTypeInLower, true, out var parsedFuelType))
                {
                    return Ok(new { Message = $"Invalid fuel type: {fuelType}" });
                }
                _carService.FillWith(fuelType);
                return Ok(new { Message = $"Car tank filled with {fuelType} fuel." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = $"Error filling with fuel: {ex.Message}" });
            }
        }

        [HttpGet("honk")]
        public ActionResult<string> Honk()
        {
            try
            {
                return Ok(new { Sound = _carService.Honk() });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = $"Error honking: {ex.Message}" });
            }
        }
    }
}
