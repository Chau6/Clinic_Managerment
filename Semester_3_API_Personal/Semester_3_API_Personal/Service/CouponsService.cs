
using Semester_3_API_Personal.Models;

namespace Semester_3_API_Personal.Service;


public interface CouponsService
{
    // ====== Find / Search / Filter
    // Find
    public dynamic findAll();
    public dynamic searchByName(string name);

    public bool create(Coupon coupon);
    public bool update(Coupon coupon);

    // ====== Delete
    public bool Delete(int id);
}
