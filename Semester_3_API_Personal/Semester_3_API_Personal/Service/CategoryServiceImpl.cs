using Semester_3_API_Personal.Models;
using System.Diagnostics;

namespace Semester_3_API_Personal.Service;

public class CategoryServiceImpl : CategoryService
{
    private DatabaseContext db;
    private IConfiguration configuration;

    public CategoryServiceImpl(DatabaseContext db, IConfiguration configuration)
    {
        this.db = db;
        this.configuration = configuration;
    }

    public bool Create(Category category)
    {
        try
        {
            db.Categories.Add(category);
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
            db.Categories.Remove(db.Categories.Find(id));
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Edit(Category category)
    {
        try
        {
            db.Categories.Update(category);
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
        return db.Categories.Where(c => c.CategoryId == id).Select(c => new
        {
            categoryId = c.CategoryId,
            categoryName = c.CategoryName
        }).SingleOrDefault();
    }

    public dynamic findAll()
    {
        return db.Categories.Select(c => new
        {
            categoryId = c.CategoryId,
            categoryName = c.CategoryName
        }).OrderByDescending(c => c.categoryId).ToList();
    }
}
