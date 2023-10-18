using DevFreela.Core.DTO;
using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        public Task<List<Project>> GetAllAsync();
        public Task<ProjectDto> GetByIdAsync(int id);
        public Task<int> CreateAsync(Project project);
        public Task CreateCommentAsync(ProjectComment comment);
        public Task DeleteProjectAsync(int id);
        public Task StartProjectAsync(int id);
        public Task FinishProjectAsync(int id);

    }
}
