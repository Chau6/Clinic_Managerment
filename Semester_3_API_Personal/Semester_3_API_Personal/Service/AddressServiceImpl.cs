using Semester_3_API_Personal.Models;

namespace Semester_3_API_Personal.Service;

public class AddressServiceImpl : AddressService
{

    private DatabaseContext db;
    private IConfiguration configuration;

    public AddressServiceImpl(DatabaseContext db, IConfiguration configuration)
    {
        this.db = db;
        this.configuration = configuration;
    }

    public dynamic findWardsByDistrict(string district)
    {
        return db.Wards.Where(w => w.DistrictCode == district).Select(w => new
        {
            code = w.Code,
            name = w.Name,
            name_en = w.NameEn,
            fullname = w.FullName,
            fullname_en = w.FullNameEn,
            code_name = w.CodeName,
            district = w.DistrictCode,
            administrative_unit_id = w.AdministrativeUnitId
        }).SingleOrDefault();
    }

    public dynamic findDistrictByProvince(string province)
    {
        return db.Districts.Where(d => d.ProvinceCode == province).Select(d => new
        {
            code = d.Code,
            name = d.Name,
            name_en = d.NameEn,
            fullname = d.FullName,
            fullname_en = d.FullNameEn,
            code_name = d.CodeName,
            province_code = d.ProvinceCode,
            administrative_unit_id = d.AdministrativeUnitId
        }).SingleOrDefault();
    }

    public dynamic findAllProvince()
    {
        return db.Provinces.Select(p => new
        {
            code = p.Code,
            name = p.Name,
            //name_en = p.NameEn,
            fullname = p.FullName,
            //fullname_en = p.FullNameEn,
            code_name = p.CodeName,
            //administrative_unit_id = p.AdministrativeUnitId,
            //administrative_region_id = p.AdministrativeRegionId
        }).OrderByDescending(p => p.code).ToList();
    }

}