using Semester_3_API_Personal.Models;
using System.Diagnostics;

namespace Semester_3_API_Personal.Service;

public class CartServiceImpl : CartService
{
    private DatabaseContext db;
    private IConfiguration configuration;

    public CartServiceImpl(DatabaseContext db, IConfiguration configuration)
    {
        this.db = db;
        this.configuration = configuration;
    }

    public bool Create(Cart cart)
    {
        try
        {
            db.Carts.Add(cart);
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
            db.Carts.Remove(db.Carts.Find(id));
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Edit(Cart cart)
    {
        try
        {
            db.Carts.Update(cart);
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public dynamic findByAccountId(int id) //account_id
    {
        return db.Carts.Where(c => c.AccountId == id && c.Status == true).Select(c => new
        {
            cartId = c.CartId,
            accountId = c.AccountId,
            productName = c.Product.ProductName,
            productPrice = c.Product.Price,
            quantity = c.Quantity,
            status = c.Status,
        }).OrderByDescending(c => c.cartId).ToList();
    }

    public dynamic findByCartId(int id) //cart_id
    {
        return db.Carts.Where(c => c.CartId == id).Select(c => new
        {
            cartId = c.CartId,
            accountId = c.AccountId,
            productName = c.Product.ProductName,
            productPrice = c.Product.Price,
            quantity = c.Quantity,
            status = c.Status,
        }).SingleOrDefault();
    }

    public dynamic findAll()
    {
        return db.Carts.Select(c => new
        {
            cartId = c.CartId,
            accountId = c.AccountId,
            createAt = c.CreatedAt,
            updateAt = c.UpdatedAt
        }).OrderByDescending(c => c.cartId).ToList();
    }
}
