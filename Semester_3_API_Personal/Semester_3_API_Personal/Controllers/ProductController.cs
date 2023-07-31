using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Semester_3_API_Personal.Helper;
using Semester_3_API_Personal.Models;
using Semester_3_API_Personal.Service;
using System.Diagnostics;

namespace Semester_3_API_Personal.Controllers;
[Route("api/admin/product")]
public class ProductController : Controller
{
    private ProductService productService;
    private IWebHostEnvironment webHostEnvironment;
    private IConfiguration configuration;

    public ProductController(ProductService productService, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
    {
        this.productService = productService;
        this.webHostEnvironment = webHostEnvironment;
        this.configuration = configuration;
    }

    [Produces("application/json")]
    [HttpGet("findAll")]
    public IActionResult findAll()
    {
        try
        {
            return Ok(productService.findAll());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpGet("findAll2")]
    public IActionResult findAll2()
    {
        try
        {
            return Ok(productService.findAll2());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpGet("findTwo")]
    public IActionResult findTwo()
    {
        try
        {
            return Ok(productService.findTwo());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpGet("findThree")]
    public IActionResult FindThree()
    {
        try
        {
            return Ok(productService.findThree());
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
            return Ok(productService.find(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpGet("find2/{id}")]
    public IActionResult Find2(int id)
    {
        try
        {
            return Ok(productService.find2(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpGet("findDetailById/{id}")]
    public IActionResult FindDetailById(int id)
    {
        try
        {
            return Ok(productService.findDetailById(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpGet("searchByKeyword/{keyword}")]
    public IActionResult SearchByKeyword(string keyword)
    {
        try
        {
            return Ok(productService.searchByKeyword(keyword));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpPost("create")]
    public IActionResult Create([FromBody] Product product)
    {
        try
        {
            return Ok(new
            {
                status = productService.Create(product)
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
    public IActionResult Edit([FromBody] Product product)
    {
        try
        {
            product.UpdatedAt = DateTime.Now;
            return Ok(productService.Edit(product));
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
            return Ok(new
            {
                status = productService.Delete(id)
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }

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

            var product = productService.findByIdNoTracking(id);
            product.Image = fileName;
            product.UpdatedAt = DateTime.Now;

            return Ok(productService.Edit(product));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpGet("edit/{id}/{newHide}")]
    public IActionResult hideProduct(int id, int newHide)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Product SET hide = @newHide WHERE product_id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newHide", newHide);
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        return Ok(new
                        {
                            status = true
                        });
                    }
                    else
                    {
                        return NotFound("Product not found.");
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
