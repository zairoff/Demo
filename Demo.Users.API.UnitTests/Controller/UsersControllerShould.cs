using AutoFixture;
using Demo.RabbitMQ.Settings.Models.User;
using Demo.Users.API.Controllers;
using Demo.Users.API.Dtos;
using Demo.Users.API.Mapper;
using Demo.Users.API.Models;
using Demo.Users.API.Repository;
using FluentAssertions;
using MassTransit;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Users.API.UnitTests.Controller
{
    public class UsersControllerShould
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUserMapper _userMapper;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly UsersController _usersController;
        private readonly Fixture _fixture;

        public UsersControllerShould()
        {
            _usersRepository = Substitute.For<IUsersRepository>();
            _userMapper = Substitute.For<IUserMapper>();
            _publishEndpoint = Substitute.For<IPublishEndpoint>();
            _fixture = new Fixture();

            _usersController = new UsersController(_usersRepository, _userMapper, _publishEndpoint);
        }

        [Fact]
        public async Task GetAll()
        {
            var users = _fixture.CreateMany<User>();

            _usersRepository.GetAllAsync().Returns(users);

            var result = (OkObjectResult) await _usersController.GetAll();

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get()
        {
            var user = _fixture.Create<User>();
            var userId = _fixture.Create<Guid>();

            _usersRepository.GetAsync(userId).Returns(user);

            var result = (OkObjectResult)await _usersController.Get(userId);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetByName()
        {
            var users = _fixture.CreateMany<User>();
            var name = _fixture.Create<string>();

            _usersRepository.FindAsync(u => u.Name.Equals(name)).Returns(users);

            var result = (OkObjectResult)await _usersController.GetByName(name);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Create()
        {
            var user = _fixture.Create<User>();
            var userCreate = _fixture.Create<UserCreate>();
            var userCreated = _fixture.Create<UserCreated>();

            _userMapper.MapUser(userCreate).Returns(user);
            _usersRepository.AddAsync(user).Returns(Task.FromResult);
            _publishEndpoint.Publish(Arg.Any<UserCreated>()).Returns(Task.FromResult);

            var result = (CreatedAtActionResult)await _usersController.Create(userCreate);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task Update()
        {
            var user = _fixture.Create<User>();
            var userUpdate = _fixture.Create<UserUpdate>();
            var userId = _fixture.Create<Guid>();

            _usersRepository.GetAsync(userId).Returns(user);
            _userMapper.MapUser(userUpdate).Returns(user);
            _publishEndpoint.Publish(Arg.Any<UserUpdated>()).Returns(Task.FromResult);

            var result = (OkObjectResult)await _usersController.Update(userId, userUpdate);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Update_NotFound()
        {
            User user = null;
            var userId = _fixture.Create<Guid>();
            var userUpdate = _fixture.Create<UserUpdate>();

            _usersRepository.GetAsync(userId).Returns(user);

            var result = (NotFoundObjectResult) await _usersController.Update(userId, userUpdate);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task Delete()
        {
            var user = _fixture.Create<User>();
            var userId = _fixture.Create<Guid>();

            _usersRepository.GetAsync(userId).Returns(user);
            _publishEndpoint.Publish(Arg.Any<UserUpdated>()).Returns(Task.FromResult);

            var result = (OkObjectResult)await _usersController.Delete(userId);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Delete_NotFound()
        {
            User user = null;
            var userId = _fixture.Create<Guid>();

            _usersRepository.GetAsync(userId).Returns(user);

            var result = (NotFoundObjectResult)await _usersController.Delete(userId);

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
        }
    }
}
