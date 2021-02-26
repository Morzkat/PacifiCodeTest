using KHahn.ApplicationProcess.February2021.Data.DataAccess;
using KHahn.ApplicationProcess.February2021.Domain.Interfaces.Repositories;
using KHahn.ApplicationProcess.February2021.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHahn.ApplicationProcess.February2021.Data.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAssetsRepository AssetsRepository { get; set; }
        private readonly KHahnApplicationProcessContext _kHahnApplicationProcessContext;

        public UnitOfWork(KHahnApplicationProcessContext kHahnApplicationProcessContext, IAssetsRepository assetsRepository)
        {
            _kHahnApplicationProcessContext = kHahnApplicationProcessContext;
            AssetsRepository = assetsRepository;
        }

        public void Dispose() => _kHahnApplicationProcessContext.Dispose();

        public async Task<int> SaveAsync() => await _kHahnApplicationProcessContext.SaveChangesAsync();
    }
}
