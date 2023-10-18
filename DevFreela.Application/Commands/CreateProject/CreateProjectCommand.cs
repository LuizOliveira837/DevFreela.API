using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    {
        public CreateProjectCommand(string title, string description, int idClient, int idFreelance, decimal? totalCost)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelance = idFreelance;
            TotalCost = totalCost;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int IdClient { get; set; }
        public int IdFreelance { get; set; }
        public decimal? TotalCost { get; set; }

    }
}
