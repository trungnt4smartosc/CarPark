using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.ViewModels
{
    public class LoginResultModel : ResultModel
    {
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
