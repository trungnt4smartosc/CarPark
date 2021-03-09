using Application.Tests.Mock;
using AutoMapper;
using CarPark.Application.ApplicationUsers;
using CarPark.Domain.ApplicationUsers;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace API.Tests.ApplicationUsers
{
    public class ApplicationUsers_Tests
    {
        public ApplicationUsers_Tests()
        {

        }
        
        [Fact]
        public async Task Should_Create_Valid_User()
        {
            // Arrange
            var repo = Substitute.For<IApplicationUserRepository>();
            var service = new ApplicationUserService(repo, Mock.Mapper);
            var model = new ApplicationUserDto
            {
                FirstName = "Trung",
                LastName = "Test",
                Email = "trungnt5@smartosc.com",
                ContactNumber = "0349049xxx",
                Password = "123456"
            };

            // Act
            var result = await service.Create(model);

            // Assert
            await repo.Received(1).Add(Arg.Is<ApplicationUser>(x => x.Email == model.Email));
        }
    }
}
