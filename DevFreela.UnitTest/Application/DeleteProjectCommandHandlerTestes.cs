using DevFreela.Application.Commands.DeleteProject;
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
    public class DeleteProjectCommandHandlerTestes
    {
        
        [Fact]
        public async void DataId_Executed_DeletedProject()
        {
            //AAA
            //ARRANGE
            var command = new DeleteProjectCommand(1);


            var projectRepositoryMock = new Mock<IProjectRepository>();

            var commandHandler = new DeleteProjectCommandHandler(projectRepositoryMock.Object);

            //Act
            commandHandler.Handle(command, new CancellationToken());

            //Assert

            projectRepositoryMock.Verify(pr=> pr.DeleteProjectAsync(command.Id), Times.Once());



        }


    }
}
