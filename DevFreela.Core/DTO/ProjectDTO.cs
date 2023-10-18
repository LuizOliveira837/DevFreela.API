using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.DTO
{
    public class ProjectDto
    {
        public ProjectDto(int id, string title, string description, decimal? totalCost, DateTime? startedAt, DateTime? finishedAt, string clientFullName, string freelaFullName)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            ClientFullName = clientFullName;
            FreelaFullName = freelaFullName;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? TotalCost { get; set; }
        public string FreelaFullName { get; set; }
        public string ClientFullName { get; set; }

        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
    }
}
