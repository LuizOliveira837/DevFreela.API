using DevFreela.Application.Commands.CreateProject;
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
    public class CreateProjectCommandHandlerTests
    {

        [Fact]
        public async Task InputDataIsOkay_Executed_ReturnProjectId()
        {
            //AAA
            //ARRANGE
            var projectInput = new CreateProjectCommand(
                "Projeto Caixa",
                "Porjeto que registra caixas",
                1,
                2,
                100
                );

            var projectRepository =  new Mock<IProjectRepository>();

            var commandHandler = new CreateProjectCommandHandler(projectRepository.Object);

            //ACTION

            var id = commandHandler.Handle(projectInput, new CancellationToken());

            //ASSERT

            Assert.NotNull( id );   


        }
    }
}
