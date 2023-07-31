using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Semester_3_API_Personal.Helper;
using Semester_3_API_Personal.Helpers;
using Semester_3_API_Personal.Models;
using Semester_3_API_Personal.Service;
using System.Diagnostics;
using System.Globalization;


namespace Semester_3_API_Personal.Controllers;
[Route("api/admin/account")]
public class AccountController : Controller
{
    private AccountService accountService;
    private IConfiguration configuration;
    private IWebHostEnvironment webHostEnvironment;

    public AccountController(AccountService accountService, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {
        this.accountService = accountService;
        this.configuration = configuration;
        this.webHostEnvironment = webHostEnvironment;
    }

    // Find All
    [Produces("application/json")]
    [HttpGet("findAll")]
    public IActionResult FindAll()
    {
        try
        {
            return Ok(accountService.findAll());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpGet("find/{id}")]
    public IActionResult Find(int id)
    {
        try
        {
            return Ok(accountService.find(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    // Find By Email
    [Produces("application/json")]
    [HttpGet("findByEmail/{email}")]
    public IActionResult findbyEmail(string email)
    {
        try
        {
            return Ok(accountService.findbyEmail(email));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }

    // ===============================
    // ============== POST
    // ===============================

    // Login
    [Produces("application/json")]
    [HttpPost("login")] //for admin and superadmin
    public IActionResult Login([FromBody] Login login)
    {   
        try
        {
            return Ok(accountService.login(login.Email, login.Password));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpPost("login2")] //for user
    public IActionResult Login2([FromBody] Login login)
    {
        try
        {
            return Ok(accountService.login2(login.Email, login.Password));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }

    // Create New Account
    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPost("register")]
    public IActionResult Register([FromBody] Account account)
    {
        try
        {
            if (accountService.CheckMail(account.Email))
            {
                return Ok(false);
            }

            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            account.Status = false;
            account.SecurityCode = RandomHelper.RandomString(4);

            // Mail
            if (accountService.register(account))
            {
                //Send mail
                var content = "Security Code: " + account.SecurityCode;
                content += "<br><hr><br>";
                content += "<a href='http://localhost:5208/api/admin/account/verify/" + account.Email + "/" + account.SecurityCode + "'>Click here to Verify Email</a>";
                var mailHelper = new MailHelper(configuration);
                mailHelper.Send(configuration["Gmail:Username"], account.Email, "Verify", content);

                return Ok(true);
            }
            else
            {
                return Ok(false);
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }

    // Create New Account
    [Produces("application/json")]
    [HttpGet("verify/{email}/{securityCode}")]
    public IActionResult VerifyCode(string email, string securityCode)
    {
        return Ok(accountService.Active(email, securityCode));
    }


    // ===============================
    // ============== PUT
    // ===============================
    [Produces("application/json")]
    [HttpPost("uploadFile/{id}")]
    public IActionResult UploadFile(int id, IFormFile file)
    {
        try
        {
            //upload file
            var fileName = FileHelper.generateFileName(file.FileName);
            var path = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            var account = accountService.findByIdNoTracking(id);
            account.Avatar = fileName;
            account.UpdatedAt = DateTime.Now;

            return Ok(accountService.edit(account));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    // Update Information Account
    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPut("edit")]
    public IActionResult UpdateInformation([FromBody] Account account)
    {
        try
        {
            account.UpdatedAt = DateTime.Now;

            return Ok(accountService.edit(account));

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }

    // ===============================
    // ============== DELETE
    // ===============================

    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            return Ok(new
            {
                status = accountService.Delete(id)
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }
}
