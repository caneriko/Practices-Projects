using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.ViewModels.Contact;

namespace Victory.Core.Services
{
    public interface IContactService
    {
        Task<List<ContactListViewModel>> GetAllActiveContactsAsync();

        Task<UpdateContactViewModel> GetByIdAsync(int id);

        Task UpdateAsync(UpdateContactViewModel viewModel);

        Task AddAsync(AddContactViewModel viewModel);

        Task SafeDeleteAsync(int id); 
    }
}

