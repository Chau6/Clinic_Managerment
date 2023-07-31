using Semester_3_API_Personal.Models;

namespace Semester_3_API_Personal.Service;

public interface CategoryService
{
    public dynamic findAll();
    public bool Create(Category category);
    public bool Edit(Category category);
    public bool Delete(int id);
    public dynamic find(int id);
}
