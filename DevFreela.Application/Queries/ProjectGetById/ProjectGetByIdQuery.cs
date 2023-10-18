﻿using DevFreela.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.ProjectGetById
{
    public class ProjectGetByIdQuery : IRequest<ProjectDetailsViewModel>
    {
        public ProjectGetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
