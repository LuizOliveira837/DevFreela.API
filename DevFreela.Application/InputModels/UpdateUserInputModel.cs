using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.InputModels
{
    public class UpdateUserInputModel
    {
        public UpdateUserInputModel(int id, string fullName, string email)
        {
            FullName = fullName;
            Email = email;
            Id = id;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public int Id { get; private set; }


    }
}
