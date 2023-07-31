


using Semester_3_API_Personal.Models;
using System.Diagnostics;

namespace Semester_3_API_Personal.Service;

public class OrderDetailServiceImpl : OrderDetailService
{
    private DatabaseContext db;
    private IConfiguration configuration;
    private OrderService orderService;

    public OrderDetailServiceImpl(DatabaseContext _db, IConfiguration configuration)
    {
        db = _db;
        this.configuration = configuration;
    }


    // ============================== 
    // Create
    // ============================== 
    public bool create(OrderDetail orderDetail)
    {
        try
        {
            db.OrderDetails.Add(orderDetail);
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
    public dynamic findOrderDetail(int id)
    {
        return db.OrderDetails.Where(p => p.Order.AccountId == id).Select(order => new
        {
            id = order.OrderId,
            accountId = order.Order.AccountId,
            accountName = order.Order.Account.Firstname + ' ' + order.Order.Account.Lastname,
            productId = order.Product.ProductName,
            createdAt = order.CreatedAt,
            updatedAt = order.UpdatedAt,
        }).ToList();
    }


    // Update
    public bool update(OrderDetail orderDetail)
    {
        try
        {
            db.Entry(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            db.OrderDetails.Remove(db.OrderDetails.Find(id));
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }


}
