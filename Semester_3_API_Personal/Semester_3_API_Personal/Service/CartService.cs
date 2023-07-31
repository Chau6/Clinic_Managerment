using Semester_3_API_Personal.Models;

namespace Semester_3_API_Personal.Service;

public interface CartService
{
    public dynamic findAll();
    public bool Create(Cart cart);
    public bool Edit(Cart cart);
    public bool Delete(int id);
    public dynamic findByAccountId(int id);
    public dynamic findByCartId(int id);
}
