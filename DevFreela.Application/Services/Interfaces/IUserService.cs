using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        public IList<UserViewModel> GetAll();
        //public UserViewModel GetById(int Id);
        public void Create(NewUserInputModel input);
       // public void Update(UpdateUserInputModel updateUserInputModel);
        //public void Disable(int id);

    }
}
