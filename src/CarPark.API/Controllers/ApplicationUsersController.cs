using CarPark.API.Ultilities;
using CarPark.API.ViewModels;
using CarPark.Application.ApplicationUsers;
using CarPark.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarPark.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationUsersController : ControllerBase
    {
        private readonly IApplicationUserService _userService;
        private readonly IJwtManager _jwtManager;

        public ApplicationUsersController(IApplicationUserService userService, IJwtManager jwtManager)
        {
            _userService = userService;
            _jwtManager = jwtManager;
        }

        [HttpPost]
        [Route("/Create")]
        public async Task<IActionResult> Create(ApplicationUserDto model)
        {
            var user = await _userService.Create(model);

            if(user == null)
            {
                return Ok(new ResultModel
                {
                    Success = false,
                    Message = Constants.Users.CreateAccountFail
                });
            }

            return Ok(new ResultModel
            {
                Success = true,
                Message = Constants.Users.CreateAccountSuccess
            });
        }

        [HttpPost]
        [Route("/Login")]
        public async Task<IActionResult> Login(BaseApplicationUserDto model)
        {
            var user = await _userService.GetUserByLogin(model);

            if (user == null)
            {
                return Ok(new LoginResultModel
                {
                    Success = false,
                    Message = Constants.Users.LoginAccountFail
                });
            }

            var tokenString = _jwtManager.GenerateToken(user);

            return Ok(new LoginResultModel
            {
                Success = true,
                Message = Constants.Users.LoginAccountSuccess,
                Token = tokenString
            });
        }

        [HttpGet]
        [Route("/Details")]
        [Authorize]
        public async Task<IActionResult> Details(Guid id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return Ok(new ResultModel
                {
                    Success = false,
                    Message = Constants.Users.LoginAccountFail
                });
            }

            return Ok(user);
        }
    }
}
