﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCrud.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        void Commit();

        Task CommitAsync();
    }
}
