using KHahn.ApplicationProcess.February2021.Domain.Interfaces.HttpClient;
using KHahn.ApplicationProcess.February2021.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KHahn.ApplicationProcess.February2021.Domain.BusinessLogic.HttpClient
{
    public class CountryHttpClient : ICountryHttpClient
    {
        private readonly IHttpClientFactory _clientFactory;

        public CountryHttpClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<bool> CountryExist(string countryName)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://restcountries.eu/rest/v2/name/{countryName}?fullText=true&fields=name;");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var countries = await JsonSerializer.DeserializeAsync<IEnumerable<Country>>(responseStream);

                return countries.Any();
            }

            return false;
        }
    }
}
