using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Semester_3_API_Personal.Models;
using Semester_3_API_Personal.Service;
using System.Diagnostics;
using static Azure.Core.HttpHeader;

namespace Semester_3_API_Personal.Controllers;
[Route("api/admin/category")]
public class CategoryController : Controller
{
    private CategoryService categoryService;
    private IWebHostEnvironment webHostEnvironment;
    private IConfiguration configuration;

    public CategoryController(CategoryService categoryService, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
    {
        this.categoryService = categoryService;
        this.webHostEnvironment = webHostEnvironment;
        this.configuration = configuration;
    }

    [Produces("application/json")]
    [HttpGet("findAll")]
    public IActionResult findAll()
    {
        try
        {
            return Ok(categoryService.findAll());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpGet("find/{id}")]
    public IActionResult Find(int id)
    {
        try
        {
            return Ok(categoryService.find(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpPost("create")]
    public IActionResult Create([FromBody] Category category)
    {
        try
        {
            return Ok(new
            {
                status = categoryService.Create(category)
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpPut("edit")]
    public IActionResult Edit([FromBody] Category category)
    {
        try
        {
            return Ok(categoryService.Edit(category));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            if (categoryService.Delete(id)) //true nếu cate này k phải là cha
            {
                return Ok(new
                {
                    status = true
                });
            }
            else //false nếu cate này là cha
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Category SET parent_id = NULL WHERE parent_id = @id;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        if (categoryService.Delete(id))
                        {
                            return Ok(new
                            {
                                status = true
                            });
                        }
                        else
                        {
                            return Ok(new
                            {
                                status = false
                            });
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }
}
