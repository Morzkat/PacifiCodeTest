using KHahn.ApplicationProcess.February2021.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHahn.ApplicationProcess.February2021.Domain.Models.DTOs
{
    public class AssetDTO
    {
        public int ID { get; set; }
        public string AssetName { get; set; }
        public Department Department { get; set; }
        public string CountryOfDepartment { get; set; }
        public string EmailAdressOfDepartment { get; set; }
        public string PurchaseDate { get; set; }
        public bool broken { get; set; }
    }
}
