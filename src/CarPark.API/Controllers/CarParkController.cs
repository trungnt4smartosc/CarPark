using CarPark.Application.CarPark;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CarParkController : Controller
    {
        private readonly ICarParkService _carParkService;

        public CarParkController(ICarParkService carParkService)
        {
            _carParkService = carParkService;
        }

        [HttpGet]
        [Route("availability")]
        public async Task<IActionResult> GetCarParkAvailability()
        {
            var result = await _carParkService.GetCarParkAvailabilities();
            return Ok(result);
        }
    }
}
