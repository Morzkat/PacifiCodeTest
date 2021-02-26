using KHahn.ApplicationProcess.February2021.Domain.Models.Entities;
using KHahn.ApplicationProcess.February2021.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHahn.ApplicationProcess.February2021.Data.Persistence.Repositories
{
    class AssetsRepository : Repository<Asset>, IAssetsRepository
    {
        public AssetsRepository(DbSet<Asset> assets) : base(assets)
        {
        }
    }
}
