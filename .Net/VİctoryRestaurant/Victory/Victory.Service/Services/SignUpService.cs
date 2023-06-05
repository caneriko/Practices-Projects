using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            var signUps = await _unitOfWork.GetRepository<Signup>().GetAllAsync(x=>x.IsActive==true);

            var signUpModels = _mapper.Map<List<SignUpViewModel>>(signUps);

            return signUpModels;

        }


        public async Task AddAsync(AddSignUpViewModel viewModel)
        {
            var entity = _mapper.Map<Signup>(viewModel);

            await _unitOfWork.GetRepository<Signup>().AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<UpdateSignUpViewModel> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<Signup>().GetByIdAsync(id);

            var map = _mapper.Map<UpdateSignUpViewModel>(entity);

            return map;
        }

        public async Task UpdateAsync(UpdateSignUpViewModel viewModel)
        {
            var entity = _mapper.Map<Signup>(viewModel);

            await _unitOfWork.GetRepository<Signup>().UpdateAsync(entity);

            await _unitOfWork.SaveAsync();
        }

        public async Task SafeDeleteAsync(int id)
        {

            var entity = await _unitOfWork.GetRepository<Signup>().GetByIdAsync(id);

            entity.IsActive=false;

            await _unitOfWork.GetRepository<Signup>().UpdateAsync(entity);

            await _unitOfWork.SaveAsync();


        }



    }
}
