using EmployeeApp.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmpAppDbContext _empAppDbContext;
        public void Commit()
        {
            _empAppDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _empAppDbContext.SaveChangesAsync();
        }
    }
}
