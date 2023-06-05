using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.ViewModels.SigUp;

namespace Victory.Core.Services
{
    public interface ISignUpService
    {
        Task<List<SignUpViewModel>> GetAllActiveSignUps();

        Task<UpdateSignUpViewModel> GetByIdAsync(int id);

        Task UpdateAsync(UpdateSignUpViewModel viewModel);

        Task AddAsync(AddSignUpViewModel viewModel);

        Task SafeDeleteAsync(int id);
    }
}
