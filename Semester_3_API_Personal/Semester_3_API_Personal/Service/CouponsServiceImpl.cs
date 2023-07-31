

using Semester_3_API_Personal.Models;
using System.Diagnostics;

namespace Semester_3_API_Personal.Service;

public class CouponsServiceImpl : CouponsService
{
    private DatabaseContext db;
    private IConfiguration configuration;
    private CouponsService couponsService;

    public CouponsServiceImpl(DatabaseContext _db, IConfiguration configuration)
    {
        db = _db;
        this.configuration = configuration;
    }


    // ============================== 
    // Create
    // ============================== 
    public bool create(Coupon coupon)
    {
        try
        {
            db.Coupons.Add(coupon);
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    // ============================== 
    // FInd
    // ============================== 

    // Find All
    public dynamic findAll()
    {
        return db.Coupons.Select(coupon => new
        {
            coupon_id = coupon.CouponId,
            coupon_type_id = coupon.CouponTypeId,
            coupon_name = coupon.CouponName,
            discount = coupon.Discount,
            discription = coupon.Description,
            expired_day = coupon.ExpiredDay,
            createdAt = coupon.CreatedAt
        }).ToList();
    }

    // Search By Name
    public dynamic searchByName(string name)
    {
        return db.Coupons.Where(p => p.CouponName.Contains(name)).Select(coupon => new
        {
            coupon_id = coupon.CouponId,
            coupon_type_id = coupon.CouponTypeId,
            coupon_name = coupon.CouponName,
            discount = coupon.Discount,
            discription = coupon.Description,
            expired_day = coupon.ExpiredDay,
            createdAt = coupon.CreatedAt
        }).ToList();
    }

    // Update
    public bool update(Coupon coupon)
    {
        try
        {
            db.Entry(coupon).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
    
    // Delete 
    public bool Delete(int id)
    {
        try
        {
            db.Coupons.Remove(db.Coupons.Find(id));
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

   
}
