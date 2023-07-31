


using Semester_3_API_Personal.Models;
using System.Diagnostics;

namespace Semester_3_API_Personal.Service;

public class OrderServiceImpl : OrderService
{
    private DatabaseContext db;
    private IConfiguration configuration;
    private OrderService orderService;

    public OrderServiceImpl(DatabaseContext _db, IConfiguration configuration)
    {
        db = _db;
        this.configuration = configuration;
    }


    // ============================== 
    // Create
    // ============================== 
    public bool create(Order order)
    {
        try
        {
            db.Orders.Add(order);
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
        return db.Orders.Select(order => new
        {
            orderId = order.OrderId,
            accountId = order.AccountId,
            totalPrice = order.TotalPrice,
            orderStatusId = order.OrderStatusId,
            paymentId = order.PaymentId,
            couponId = order.CouponId,
            createdAt = order.CreatedAt,
            updatedAt = order.UpdatedAt,
        }).ToList();
    }

    // Update
    public bool update(Order order)
    {
        try
        {
            db.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            db.Orders.Remove(db.Orders.Find(id));
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }


}
