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
    public class AccountProcessManager : IAccountProcessService
    {
        private readonly IAccountProcessDal _accountProcessDal;
        public void Delete(AccountProcess t)
        {
            _accountProcessDal.Delete(t);
        }

        public List<AccountProcess> GetAll()
        {
            return _accountProcessDal.GetAll();
        }

        public AccountProcess GetById(int id)
        {
            return _accountProcessDal.GetById(id);
        }

        public void Insert(AccountProcess t)
        {
            _accountProcessDal.Insert(t);
        }

        public void Update(AccountProcess t)
        {
            _accountProcessDal.Update(t);
        }
    }
}
