using Dapper;
using DevFreela.Core.DTO;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories.Implementation
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private string _connectionString;
        public ProjectRepository(DevFreelaDbContext context, IConfiguration configution)
        {
            _dbContext = context;
            _configuration = configution;
            _connectionString = configution.GetConnectionString("DevFreelaCs"); ;
        }

        public async Task<int> CreateAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);

            await _dbContext.SaveChangesAsync();

            return project.Id;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<ProjectDto> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                var sqlCommand = "select " +
                                    " P.Id " +
                                    ",p.Title " +
                                    ",P.[Description] as 'Description'" +
                                    ",P.TotalCost as 'TotalCost'" +
                                    ",p.StartedAt as 'StartedAt'" +
                                    ",p.FinishedAt   " +
                                    ",C.FullName  as 'ClientFullName'" +
                                    ",F.FullName  'FreelaFullName'" +
                                "from	projects P (nolock)" +
                                "inner " +
                                "join	Users	C (nolock)" +
                                "ON		P.IdClient = C.Id " +
                                "inner " +
                                "join	Users	F (nolock)" +
                                "ON		P.IdFreelancer = F.Id " +
                                "WHERE  P.ID = @Id";


                var project = await connection.QueryFirstAsync<ProjectDto>(sqlCommand, new { Id = id });

                return project;
            }
        }

        public async Task CreateCommentAsync(ProjectComment comment)
        {
            await _dbContext.Comments.AddAsync(comment);

            _dbContext.SaveChangesAsync();

        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync<Project>(p => p.Id == id);

            project.Cancel();

            await _dbContext.SaveChangesAsync();
        }

        public async Task StartProjectAsync(int id)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync<Project>(p => p.Id == id);

            project.Start();

            _dbContext.SaveChangesAsync();
        }

        public async Task FinishProjectAsync(int id)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync<Project>(p => p.Id == id);

            project.Finish();

            _dbContext.SaveChangesAsync();
        }
    }

}
