using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;
using Victory.Core.Services;
using Victory.Core.UnitOfWork;
using Victory.Core.ViewModels.Contact;

namespace Victory.Service.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<List<ContactListViewModel>> GetAllActiveContactsAsync()
        {
            var entities = await _unitOfWork.GetRepository<Contact>().GetAllAsync(x => x.IsActive == true);

            var map = _mapper .Map<List<ContactListViewModel>>(entities);

            return map; 
        }



        public async Task<UpdateContactViewModel> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<Contact>().GetByIdAsync(id);

            var map = _mapper.Map<UpdateContactViewModel>(entity);

            return map;
        }

        public async Task UpdateAsync(UpdateContactViewModel viewModel)
        {
            var entity = _mapper.Map<Contact>(viewModel);

            await _unitOfWork.GetRepository<Contact>().UpdateAsync(entity);

            await _unitOfWork.SaveAsync();
        }


        public async Task AddAsync(AddContactViewModel viewModel)
        {
            var entity = _mapper.Map<Contact>(viewModel);

            await _unitOfWork.GetRepository<Contact>().AddAsync(entity);

            await _unitOfWork.SaveAsync();
        }


        public async Task SafeDeleteAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<Contact>().GetByIdAsync(id);

            entity.IsActive = false;

            await _unitOfWork.GetRepository<Contact>().UpdateAsync(entity);

            await _unitOfWork.SaveAsync();
            
        }



    }
}
