
using Semester_3_API_Personal.Models;

namespace Semester_3_API_Personal.Service;


public interface OrderDetailService
{
    // ====== Find / Search / Filter
    // Find
    public dynamic findOrderDetail(int id);

    public bool create(OrderDetail orderDetail);
    public bool update(OrderDetail orderDetail);

    // ====== Delete
    public bool Delete(int id);
}
