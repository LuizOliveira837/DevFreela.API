using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string title, string description, decimal? totalCost, DateTime? startedAt, DateTime? finishAt, string clientFullName, string freelaFullName)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinishAt = finishAt;
            ClientFullName = clientFullName;
            FreelaFullName = clientFullName;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? TotalCost { get; set; }
        public string FreelaFullName { get; set; }
        public string ClientFullName { get; set; }

        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishAt { get; private set; }
    }
}
