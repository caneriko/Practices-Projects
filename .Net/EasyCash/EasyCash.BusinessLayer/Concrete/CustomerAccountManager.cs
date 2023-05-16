using EasyCash.BusinessLayer.Abstract;
using EasyCash.DAL.Abstract;
using EasyCash.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.BusinessLayer.Concrete
{
    public class CustomerAccountManager : ICustomerAccountService
    {
        private readonly ICustomerAccountDal _customerAccountDal;
        public void Delete(CustomerAccount t)
        {
            _customerAccountDal.Delete(t);
        }

        public List<CustomerAccount> GetAll()
        {
           return  _customerAccountDal.GetAll();
        }

        public CustomerAccount GetById(int id)
        {
            return _customerAccountDal.GetById(id);
        }

        public void Insert(CustomerAccount t)
        {
            _customerAccountDal.Insert(t);
        }

        public void Update(CustomerAccount t)
        {
            _customerAccountDal.Update(t);
        }
    }
}
