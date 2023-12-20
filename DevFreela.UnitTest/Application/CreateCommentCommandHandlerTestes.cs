using DevFreela.Application.Commands.CreateComment;
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
    public class CreateCommentCommandHandlerTestes
    {

        [Fact]
        public async Task GivenComment_Executed_ReturnIdComment()
        {
            //AAA
            //ARRANGE
            var projectRepository = new Mock<IProjectRepository>();

            var comment = new ProjectComment("Isso é um comentario", 1, 1);
            var command = new CreateCommentCommand(comment.Content, comment.IdProject, comment.IdUser);
            var commandHandler = new CreateCommentCommandHandler(projectRepository.Object);

            //Act
            await commandHandler.Handle(command, new CancellationToken());

            //Assert

            projectRepository.Verify(pr => pr.CreateCommentAsync(It.IsAny<ProjectComment>()), Times.Once);


        }
    }
}
