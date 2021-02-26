using System;

namespace KHahn.ApplicationProcess.February2021.Domain.Models.Entities
{
    public enum Department
    {
        HQ,
        Store1,
        Store2,
        Store3,
        MaintenanceStation,
    }

    public class Asset : BaseEntity
    {
        public string AssetName { get; set; }
        public Department Department { get; set; }
        public string CountryOfDepartment { get; set; }
        public string EmailAdressOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; } //UTC
        public bool broken { get; set; }
    }

}
