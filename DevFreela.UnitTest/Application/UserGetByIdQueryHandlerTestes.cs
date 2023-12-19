using DevFreela.Application.Queries.UserGetById;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories.Implementation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTest.Application
{

    public class UserGetByIdQueryHandlerTestes
    {

        [Fact]
        public async void OneUserExists_Executed_ReturnOneUser()
        {
            //AAA
            //ARRANGE
            var userSkills = new List<UserSkill>()
            {
                new UserSkill(1, 1),
                new UserSkill(1, 2)
            };


            var user = new User("Luiz Henrique", "luizhorocha@gmail.com", new DateTime(2000, 01, 01), "Lr57282341.@Oll", "User");
            //var userView = new UserViewModel("Luiz Henrique", "luizhorocha@gmail.com", new DateTime(2000,01,01), true, userSkills, projects, projects);

            var userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock.Setup(ur=> ur.GetByIdAsync(user.Id).Result).Returns(user);

            var query = new UserGetByIdQuery(user.Id);
            var queryHandler = new UserGetByIdQueryHandler(userRepositoryMock.Object);


            //ACTION

            await queryHandler.Handle(query, new CancellationToken());

            //ASSERT

            Assert.True(user.Active);
            Assert.NotNull(user.FullName);
            Assert.NotNull(user.Password);
            Assert.NotNull(user.Email);





        }
    }
}
