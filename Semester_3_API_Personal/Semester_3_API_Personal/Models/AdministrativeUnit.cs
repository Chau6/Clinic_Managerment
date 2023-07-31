using System;
using System.Collections.Generic;

namespace Semester_3_API_Personal.Models;

public partial class AdministrativeUnit
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? FullNameEn { get; set; }

    public string? ShortName { get; set; }

    public string? ShortNameEn { get; set; }

    public string? CodeName { get; set; }

    public string? CodeNameEn { get; set; }

    public int? AccountId { get; set; }

    public virtual ICollection<District> Districts { get; set; } = new List<District>();

    public virtual ICollection<Province> Provinces { get; set; } = new List<Province>();

    public virtual ICollection<Ward> Wards { get; set; } = new List<Ward>();
}
