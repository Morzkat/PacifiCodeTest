using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHahn.ApplicationProcess.February2021.Domain.Interfaces.HttpClient
{
    public interface ICountryHttpClient
    {
        Task<bool> CountryExist(string countryName);
    }
}
