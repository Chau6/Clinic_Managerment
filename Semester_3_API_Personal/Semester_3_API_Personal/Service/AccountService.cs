
using Semester_3_API_Personal.Models;

namespace Semester_3_API_Personal.Service;


public interface AccountService
{
    public bool login(string email, string password);
    public bool login2(string email, string password);
    public bool register(Account account);
    public bool edit(Account account);
    public bool Delete(int id);
    public dynamic findAll();
    public dynamic find(int id);
    public Account findByIdNoTracking(int id);
    public dynamic findbyEmail(string email);
    public dynamic findbyStatus(bool status);
    // Check Email
    public bool CheckMail(string username);
    public dynamic VerifyCode(string account);
    public bool Active(string email, string securityCode);
}
