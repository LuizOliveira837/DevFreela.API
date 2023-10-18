using Dapper;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories.Implementation;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.SkillGetAll
{
    public class SkillGetAllQueryHandler : IRequestHandler<SkillGetAllQuery, IList<SkillViewModel>>
    {
        private readonly ISkillRepository _skillRepository;
        public SkillGetAllQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<IList<SkillViewModel>> Handle(SkillGetAllQuery request, CancellationToken cancellationToken)
        {
            var skills = await _skillRepository.GetAllAsync();

            return skills
                .Select(s => new SkillViewModel(s.Id, s.Description, s.CreatedAt))
                .ToList();
        }
    }
}
