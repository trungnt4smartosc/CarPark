using CarPark.Application.Ultilities;
using CarPark.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.CarPark
{
    public interface ICarParkService
    {
        Task<CarParkAvailabilityDto> GetCarParkAvailabilities();
    }

    public class CarParkService : ICarParkService
    {
        public async Task<CarParkAvailabilityDto> GetCarParkAvailabilities()
        {
            var httpHelper = new HttpHelper<CarParkAvailabilityDto>();

            var response = await httpHelper.SendGetRequestAsync(Constants.CarPark.CarParkAvailabilityAPI + $"?date_time={DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}");

            return response;
        }
    }
}
