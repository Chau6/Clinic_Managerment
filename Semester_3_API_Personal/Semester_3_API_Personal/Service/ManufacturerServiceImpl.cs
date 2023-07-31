using Semester_3_API_Personal.Models;
using System.Diagnostics;

namespace Semester_3_API_Personal.Service;

public class ManufacturerServiceImpl : ManufacturerService
{
    private DatabaseContext db;
    private IConfiguration configuration;

    public ManufacturerServiceImpl(DatabaseContext db, IConfiguration configuration)
    {
        this.db = db;
        this.configuration = configuration;
    }

    public bool Create(Manufacturer manufacturer)
    {
        try
        {
            db.Manufacturers.Add(manufacturer);
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            db.Manufacturers.Remove(db.Manufacturers.Find(id));
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Edit(Manufacturer manufacturer)
    {
        try
        {
            db.Manufacturers.Update(manufacturer);
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public dynamic find(int id)
    {
        return db.Manufacturers.Where(m => m.MftId == id).Select(m => new
        {
            mft_id = m.MftId,
            mft_name = m.MftName,
            mft_address = m.MftAddress,
            address_id = m.AddressId,
            mft_description = m.MftDescription
        }).SingleOrDefault();
    }

    public dynamic findAll()
    {
        return db.Manufacturers.Select(m => new
        {
            mft_id = m.MftId,
            mft_name = m.MftName,
            mft_address = m.MftAddress,
            address_id = m.AddressId,
            mft_description = m.MftDescription
        }).OrderByDescending(m => m.mft_id).ToList();
    }
}
