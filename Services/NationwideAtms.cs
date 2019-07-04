using Newtonsoft.Json;
using NW_OpenData_ATMs.Models;
using NW_OpenData_ATMs.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NW_OpenData_ATMs.Services
{
    public class NationwideAtms : IAtms
    {
        private IHttpClientFactory _clientFactory;

        private const string _baseAddress = "https://openapi.nationwide.co.uk";
        private const string _path = "/open-banking/v2.2/atms";

        public NationwideAtms(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<GeographicCoordinates>> GetAtmsGeographicCoordinatesAsync()
        {
            try
            {
                var client = _clientFactory.CreateClient();
                client.BaseAddress = new Uri(_baseAddress);
                var response = await client.GetAsync(_path); // TODO cache the response

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<AtmRootObject>(responseString);

                    return GetAtmsGeographicCoordinates(model);
                }
            }
            catch (Exception e)
            {
                // TODO log exception
            }

            return null;
        }

        private IEnumerable<GeographicCoordinates> GetAtmsGeographicCoordinates(AtmRootObject root)
        {
            var geoCoordinates = new List<GeographicCoordinates>();

            foreach (var datum in root.Data)
            {
                // I am making an assumption there will only be Nationwide Building Society
                foreach (var brand in datum.Brand)
                {
                    foreach (var atm in brand.ATM)
                    {
                        geoCoordinates.Add(atm.Location.PostalAddress.GeoLocation.GeographicCoordinates);
                    }
                }
            }

            return geoCoordinates.Take(10); // TODO remove this limit
        }
    }
}