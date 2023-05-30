using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;
using Victory.Core.Services;
using Victory.Core.UnitOfWork;
using Victory.Core.ViewModels.SigUp;

namespace Victory.Service.Services
{
    public class SignUpService : ISignUpService
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SignUpService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<SignUpViewModel>> GetAllActiveSignUps()
        {
            var signUps = await  _unitOfWork.GetRepository<Signup>().GetAllAsync(x=>x.IsActive==true);

            var signUpModels = _mapper.Map<List<SignUpViewModel>>(signUps);

            return signUpModels;

        }




    }
}
