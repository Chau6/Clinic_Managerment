

using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semester_3_API_Personal.Models;
using System.Diagnostics;
using System.Globalization;

namespace Semester_3_API_Personal.Service;

public class AccountServiceImpl : AccountService
{
    private DatabaseContext db;
    private IConfiguration configuration;
    private AccountService accountService;

    public AccountServiceImpl(DatabaseContext _db, IConfiguration configuration)
    {
        db = _db;
        this.configuration = configuration;
    }

    // Create 
    public bool register(Account account)
    {
        try
        {
            db.Accounts.Add(account);
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    // Login
    public bool login(string email, string password)
    {
        try
        {
            var account = db.Accounts.SingleOrDefault(a => a.Email == email);
            if (account != null && account.Status == true && account.RoleId != 3)
            {
                return BCrypt.Net.BCrypt.Verify(password, account.Password);
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }

    public bool login2(string email, string password)
    {
        try
        {
            var account = db.Accounts.SingleOrDefault(a => a.Email == email);
            if (account != null && account.Status == true)
            {
                return BCrypt.Net.BCrypt.Verify(password, account.Password);
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }

    public dynamic find(int id)
    {
        return db.Accounts.Where(a => a.AccountId == id).Select(acc => new
        {
            accountId = acc.AccountId,
            firstname = acc.Firstname,
            lastname = acc.Lastname,
            email = acc.Email,
            password = acc.Password,
            phoneNumber = acc.Phone,
            gender = acc.Gender,
            address = acc.Address,
            avatar = acc.Avatar,
            roleId = acc.RoleId,
            roleName = acc.Role.RoleName,
            status = acc.Status,
            securityCode = acc.SecurityCode,
            createdAt = acc.CreatedAt,
            updatedAt = acc.UpdatedAt,
        }).SingleOrDefault();
    }

    // Update Information
    public bool edit(Account account)
    {
        try
        {
            db.Accounts.Update(account);
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    // For Update If dont change password
    public Account findByIdNoTracking(int id)
    {
        return db.Accounts.AsNoTracking().SingleOrDefault(a => a.AccountId == id);
    }

    // Delete 
    public bool Delete(int id)
    {
        try
        {
            db.Accounts.Remove(db.Accounts.Find(id));
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    // ============================== 
    // FInd
    // ============================== 

    // Find All
    public dynamic findAll()
    {
        return db.Accounts.Select(acc => new
        {
            accountId = acc.AccountId,
            firstname = acc.Firstname,
            lastname = acc.Lastname,
            email = acc.Email,
            phoneNumber = acc.Phone,
            gender = acc.Gender,
            address = acc.Address,
            avatar = configuration["BaseUrl"] + "images/" + acc.Avatar,
            roleId = acc.RoleId,
            rolename = acc.Role.RoleName,
            status = acc.Status,
            createdAt = acc.CreatedAt,
            updatedAt = acc.UpdatedAt,
        }).OrderByDescending(a => a.accountId).ToList();
    }

    // Find Email
    public dynamic findbyEmail(string email)
    {
        return db.Accounts.Where(p => p.Email == email).Select(acc => new
        {
            accountId = acc.AccountId,
            firstname = acc.Firstname,
            lastname = acc.Lastname,
            email = acc.Email,
            phoneNumber = acc.Phone,
            gender = acc.Gender,
            address = acc.Address,
            avatar = configuration["BaseUrl"] + "images/" + acc.Avatar,
            roleId = acc.RoleId,
            rolename = acc.Role.RoleName,
            status = acc.Status,
            createdAt = acc.CreatedAt,
            updatedAt = acc.UpdatedAt,
        }).SingleOrDefault();
    }

    public dynamic findbyStatus(bool status)
    {
        return db.Accounts.Where(p => p.Status == status).Select(acc => new
        {
            id = acc.AccountId,
            firstname = acc.Firstname,
            lastname = acc.Lastname,
            email = acc.Email,
            phone = acc.Phone,
            gender = acc.Gender,
            address = acc.Address,
            avatar = acc.Avatar,
            roleId = acc.RoleId,
            rolename = acc.Role.RoleName,
            status = acc.Status,
            createdAt = acc.CreatedAt,
            updatedAt = acc.UpdatedAt,
        }).ToList();
    }
    public bool CheckMail(string email)
    {
        return db.Accounts.Count(p => p.Email == email) > 0;
    }

    public dynamic VerifyCode(string account)
    {
        try
        {
            db.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    public bool Active(string email, string securityCode)
    {
        try
        {
            var account = db.Accounts.FirstOrDefault(a => a.Email == email && a.SecurityCode == securityCode);
            if (account == null)
            {
                return false;
            }
            account.Status = true;
            account.SecurityCode = "USED";
            db.Accounts.Update(account);
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
}
