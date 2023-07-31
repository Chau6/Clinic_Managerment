using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Semester_3_API_Personal.Models;
using Semester_3_API_Personal.Service;
using System.Diagnostics;

namespace Semester_3_API_Personal.Controllers;
[Route("api/cart")]
public class CartController : Controller
{
    private CartService cartService;
    private IWebHostEnvironment webHostEnvironment;
    private IConfiguration configuration;

    public CartController(CartService cartService, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
    {
        this.cartService = cartService;
        this.webHostEnvironment = webHostEnvironment;
        this.configuration = configuration;
    }

    [Produces("application/json")]
    [HttpGet("findAll")]
    public IActionResult findAll()
    {
        try
        {
            return Ok(cartService.findAll());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpGet("find/{id}")]
    public IActionResult Find(int id) //account_id
    {
        try
        {
            return Ok(cartService.findByAccountId(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpGet("findByCartId/{id}")]
    public IActionResult FindByCartId(int id) //cart_id
    {
        try
        {
            return Ok(cartService.findByCartId(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpGet("addQuantity/{id}")]
    public IActionResult AddQuantity(int id) 
    {
        try
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Cart SET quantity = quantity + 1 WHERE cart_id = @id;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    return Ok(true);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpGet("subQuantity/{id}")]
    public IActionResult SubQuantity(int id)
    {
        try
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Cart SET quantity = CASE WHEN quantity > 1 THEN quantity - 1 ELSE 1 END WHERE cart_id = @id;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    return Ok(true);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpPost("create")]
    public IActionResult Create([FromBody] Cart cart)
    {
        try
        {
            return Ok(cartService.Create(cart));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpPut("edit")]
    public IActionResult Edit([FromBody] Cart cart)
    {
        try
        {
            return Ok(cartService.Edit(cart));
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
            return Ok(cartService.Delete(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }
}
