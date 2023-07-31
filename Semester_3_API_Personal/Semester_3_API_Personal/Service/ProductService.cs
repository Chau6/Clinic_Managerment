using Semester_3_API_Personal.Models;

namespace Semester_3_API_Personal.Service;

public interface ProductService
{
    public dynamic findAll();
    public dynamic findAll2();
    public dynamic findTwo();
    public dynamic findThree();
    public bool Create(Product product);
    public bool Edit(Product product);
    public bool Delete(int id);
    public dynamic find(int id);
    public dynamic find2(int id);
    public dynamic searchByKeyword(string keyword);
    public dynamic findDetailById(int id);
    public Product findByIdNoTracking(int id);
}
