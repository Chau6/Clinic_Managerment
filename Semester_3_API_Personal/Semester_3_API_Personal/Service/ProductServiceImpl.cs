using Microsoft.EntityFrameworkCore;
using Semester_3_API_Personal.Models;
using System.Diagnostics;

namespace Semester_3_API_Personal.Service;

public class ProductServiceImpl : ProductService
{
    private DatabaseContext db;
    private IConfiguration configuration;

    public ProductServiceImpl(DatabaseContext db, IConfiguration configuration)
    {
        this.db = db;
        this.configuration = configuration;
    }

    public bool Create(Product product)
    {
        try
        {
            db.Products.Add(product);
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
            db.Products.Remove(db.Products.Find(id));
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Edit(Product product)
    {
        try
        {
            db.Products.Update(product);
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public Product findByIdNoTracking(int id)
    {
        return db.Products.AsNoTracking().SingleOrDefault(p => p.ProductId == id);
    }

    public dynamic find(int id)
    {
        return db.Products.Where(p => p.ProductId == id).Select(p => new
        {
            productId = p.ProductId,
            image = configuration["BaseUrl"] + "images/" + p.Image,
            productName = p.ProductName,
            price = p.Price,
            categoryId = p.CategoryId,
            description = p.Description,
            quantity = p.Quantity,
            detail = p.Detail,
            expireDate = p.ExpireDate,
            manufacturerId = p.ManufacturerId,
            hide = p.Hide,
            createdAt = p.CreatedAt,
            updatedAt = p.UpdatedAt
        }).SingleOrDefault();
    }

    public dynamic find2(int id)
    {
        return db.Products.Where(p => p.ProductId == id).Select(p => new
        {
            productId = p.ProductId,
            image = p.Image,
            productName = p.ProductName,
            price = p.Price,
            categoryId = p.CategoryId,
            description = p.Description,
            quantity = p.Quantity,
            detail = p.Detail,
            expireDate = p.ExpireDate,
            manufacturerId = p.ManufacturerId,
            hide = p.Hide,
            createdAt = p.CreatedAt,
            updatedAt = p.UpdatedAt
        }).SingleOrDefault();
    }

    public dynamic findAll()
    {
        return db.Products.Select(p => new
        {
            productId = p.ProductId,
            image = configuration["BaseUrl"] + "images/" + p.Image,
            productName = p.ProductName,
            price = p.Price,
            categoryId = p.CategoryId,
            description = p.Description,
            quantity = p.Quantity,
            detail = p.Detail,
            expireDate = p.ExpireDate,
            manufacturerId = p.ManufacturerId,
            hide = p.Hide,
            createdAt = p.CreatedAt,
            updatedAt = p.UpdatedAt
        }).OrderByDescending(p => p.productId).ToList();
    }

    public dynamic findAll2()
    {
        return db.Products.Where(p => p.Hide != false).Select(p => new
        {
            productId = p.ProductId,
            image = configuration["BaseUrl"] + "images/" + p.Image,
            productName = p.ProductName,
            price = p.Price,
            categoryId = p.CategoryId,
            description = p.Description,
            quantity = p.Quantity,
            detail = p.Detail,
            expireDate = p.ExpireDate,
            manufacturerId = p.ManufacturerId,
            hide = p.Hide,
            createdAt = p.CreatedAt,
            updatedAt = p.UpdatedAt
        }).OrderByDescending(p => p.productId).ToList();
    }

    public dynamic findTwo()
    {
        return db.Products.Where(p => p.Hide != false).Select(p => new
        {
            productId = p.ProductId,
            image = configuration["BaseUrl"] + "images/" + p.Image,
            productName = p.ProductName,
            price = p.Price,
            categoryId = p.CategoryId,
            description = p.Description,
            quantity = p.Quantity,
            detail = p.Detail,
            expireDate = p.ExpireDate,
            manufacturerId = p.ManufacturerId,
            hide = p.Hide,
            createdAt = p.CreatedAt,
            updatedAt = p.UpdatedAt
        }).OrderByDescending(p => p.productId).Take(2).ToList();
    }

    public dynamic findThree()
    {
        return db.Products.Where(p => p.Hide != false).Select(p => new
        {
            productId = p.ProductId,
            image = configuration["BaseUrl"] + "images/" + p.Image,
            productName = p.ProductName,
            price = p.Price,
            categoryId = p.CategoryId,
            description = p.Description,
            quantity = p.Quantity,
            detail = p.Detail,
            expireDate = p.ExpireDate,
            manufacturerId = p.ManufacturerId,
            hide = p.Hide,
            createdAt = p.CreatedAt,
            updatedAt = p.UpdatedAt
        }).OrderBy(p => p.productId).Take(3).ToList();
    }

    public dynamic searchByKeyword(string keyword)
    {
        return db.Products.Where(product => product.ProductName.Contains(keyword)).Select(p => new
        {
            productId = p.ProductId,
            image = p.Image,
            productName = p.ProductName,
            price = p.Price,
            categoryId = p.CategoryId,
            description = p.Description,
            quantity = p.Quantity,
            detail = p.Detail,
            expireDate = p.ExpireDate,
            manufacturerId = p.ManufacturerId,
            hide = p.Hide,
            createdAt = p.CreatedAt,
            updatedAt = p.UpdatedAt
        }).ToList();
    }

    public dynamic findDetailById(int id)
    {
        return db.Products.Where(p => p.ProductId == id).Select(p => new
        {
            product_id = p.ProductId,
            detail = p.Detail
        }).SingleOrDefault();
    }

}
