using DevFreela.Application.Queries.SkillGetAll;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
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
    public class SkillGetAllQueryHandlerTestes
    {

        [Fact]
        public async void OneSkillExist_Executed_ReturnOneSkillViewModel()
        {
            //ARRANGE
            List<Skill> skills = new List<Skill>()
            {
                new Skill("ANDAR PELA PAREDE" )
            };

            var skillRepositoryMock = new Mock<ISkillRepository>();

            skillRepositoryMock.Setup(sr => sr.GetAllAsync().Result).Returns(skills);

            var command = new SkillGetAllQuery();
            var commandHandler = new SkillGetAllQueryHandler(skillRepositoryMock.Object);


            //ACTION

            var skillsViewModel = await commandHandler.Handle(command, new CancellationToken());

            //ASSERT

            Assert.NotNull(skillsViewModel);
            Assert.NotEmpty(skillsViewModel);

            skillRepositoryMock.Verify(sr=> sr.GetAllAsync(), Times.Once);


        }
    }
}
