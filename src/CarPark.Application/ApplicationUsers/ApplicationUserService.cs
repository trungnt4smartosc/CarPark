using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarPark.Domain.ApplicationUsers;

namespace CarPark.Application.ApplicationUsers
{
    public interface IApplicationUserService
    {
        Task<ApplicationUserDto> Create(ApplicationUserDto model);
        Task<ApplicationUserDto> GetUserByLogin(BaseApplicationUserDto model);
        Task<ApplicationUserDto> GetUserById(Guid id);
    }

    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IMapper _mapper;
        private readonly IApplicationUserRepository _applicationUserRepository;

        public ApplicationUserService(IApplicationUserRepository applicationUserRepository, IMapper mapper)
        {
            _applicationUserRepository = applicationUserRepository;
            _mapper = mapper;
        }

        public async Task<ApplicationUserDto> Create(ApplicationUserDto model)
        {
            var data = _mapper.Map<ApplicationUser>(model);
            var result = await _applicationUserRepository.Add(data);

            return _mapper.Map<ApplicationUserDto>(result);
        }

        public async Task<ApplicationUserDto> GetUserByLogin(BaseApplicationUserDto model)
        {
            var result = await _applicationUserRepository.Get(x => x.Email == model.Email && x.Password == model.Password);

            return _mapper.Map<ApplicationUserDto>(result);
        }

        public async Task<ApplicationUserDto> GetUserById(Guid id)
        {
            var result = await _applicationUserRepository.Get(x => x.Id == id);

            return _mapper.Map<ApplicationUserDto>(result);
        }
    }
}
