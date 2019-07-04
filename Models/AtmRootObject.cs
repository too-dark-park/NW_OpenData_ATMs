using System;
using System.Collections.Generic;
using static NW_OpenData_ATMs.Controllers.AtmsController;

namespace NW_OpenData_ATMs.Models
{
    // Generated using http://json2csharp.com/
    public class Meta
    {
        public DateTime LastUpdated { get; set; }
        public int TotalResults { get; set; }
        public string Agreement { get; set; }
        public string License { get; set; }
        public string TermsOfUse { get; set; }
    }

    public class Branch
    {
        public string Identification { get; set; }
    }

    public class Site
    {
        public string Identification { get; set; }
        public string Name { get; set; }
    }

    //public class GeographicCoordinates
    //{
    //    public string Latitude { get; set; }
    //    public string Longitude { get; set; }
    //}

    public class GeoLocation
    {
        public GeographicCoordinates GeographicCoordinates { get; set; }
    }

    public class PostalAddress
    {
        public List<string> AddressLine { get; set; }
        public string TownName { get; set; }
        public string Country { get; set; }
        public GeoLocation GeoLocation { get; set; }
        public string PostCode { get; set; }
    }

    public class Location
    {
        public Site Site { get; set; }
        public PostalAddress PostalAddress { get; set; }
        public string LocationCategory { get; set; }
    }

    public class ATM
    {
        public List<string> SupportedLanguages { get; set; }
        public string MinimumPossibleAmount { get; set; }
        public List<string> SupportedCurrencies { get; set; }
        public List<string> Accessibility { get; set; }
        public Branch Branch { get; set; }
        public List<string> ATMServices { get; set; }
        public string Identification { get; set; }
        public Location Location { get; set; }
    }

    public class Brand
    {
        public string BrandName { get; set; }
        public List<ATM> ATM { get; set; }
    }

    public class Datum
    {
        public List<Brand> Brand { get; set; }
    }

    public class AtmRootObject
    {
        public Meta Meta { get; set; }
        public List<Datum> Data { get; set; }
    }
}
