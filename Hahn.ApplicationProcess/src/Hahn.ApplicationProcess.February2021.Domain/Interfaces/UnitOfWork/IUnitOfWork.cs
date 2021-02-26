using KHahn.ApplicationProcess.February2021.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace KHahn.ApplicationProcess.February2021.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAssetsRepository AssetsRepository { get; set; }
        Task<int> SaveAsync();
    }
}