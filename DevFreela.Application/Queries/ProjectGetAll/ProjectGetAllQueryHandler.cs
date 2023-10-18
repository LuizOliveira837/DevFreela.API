using Dapper;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.ProjectGetAll
{
    public class ProjectGetAllQueryHandler : IRequestHandler<ProjectGetAllQuery, IList<ProjectViewModel>>
    {
        public readonly IProjectRepository _projectRepository;
        public IConfiguration Configuration { get; }
        public ProjectGetAllQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<IList<ProjectViewModel>> Handle(ProjectGetAllQuery request, CancellationToken cancellationToken)
        {

            var projects = await _projectRepository.GetAllAsync();

            var projectViewModel = projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
            .ToList();

            return projectViewModel.ToList();


        }
    }
}
