﻿namespace MyMvcApp.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        void Commit();

        Task CommitAsync();


    }
}
