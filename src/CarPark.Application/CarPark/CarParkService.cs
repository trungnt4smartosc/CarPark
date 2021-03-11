using CarPark.Application.Ultilities;
using CarPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.CarPark
{
    public interface ICarParkService
    {
        Task<List<CarParkData>> GetCarParkAvailabilities();
    }

    public class CarParkService : ICarParkService
    {
        private readonly HttpHelper<CarParkAvailabilityDto> httpHelper;

        public CarParkService()
        {
            httpHelper = new HttpHelper<CarParkAvailabilityDto>();
        }

        public async Task<List<CarParkData>> GetCarParkAvailabilities()
        {
            var response = await httpHelper.SendGetRequestAsync(Constants.CarPark.CarParkAvailabilityAPI + $"?date_time={DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}");
            
            var result = response.Items.FirstOrDefault()?.CarParkData.Take(20).ToList();

            return result;
        }
    }
}
