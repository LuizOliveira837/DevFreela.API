using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTest.Core.Entities
{
    public class ProjectTestes
    {
        [Fact]
        public void TestProjectStartWorks()
        {
            var project = new Project("API Teste", "Api para cadastrar users",1,1,10);

            project.Start();     
            
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
        }
    }
}
