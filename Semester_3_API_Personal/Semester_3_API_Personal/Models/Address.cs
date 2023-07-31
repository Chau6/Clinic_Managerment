using System;
using System.Collections.Generic;

namespace Semester_3_API_Personal.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string? RoadName { get; set; }

    public string? WardsCode { get; set; }

    public string? DistrictCode { get; set; }

    public string? ProvinceCode { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual District? DistrictCodeNavigation { get; set; }

    public virtual ICollection<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public virtual Province? ProvinceCodeNavigation { get; set; }

    public virtual Ward? WardsCodeNavigation { get; set; }
}
