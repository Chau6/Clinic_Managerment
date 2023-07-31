using Microsoft.AspNetCore.Mvc;
using Semester_3_API_Personal.Helpers;
using Semester_3_API_Personal.Models;
using Semester_3_API_Personal.Service;
using System.Diagnostics;

namespace Semester_3_API_Personal.Controllers;
[Route("api/blog")]
public class BlogController : Controller
{
    private BlogService blogService;

    public BlogController(BlogService blogService)
    {
        this.blogService = blogService;
    }
    // ===============================
    // ============== GET GET
    // ===============================

    // Find All
    [Produces("application/json")]
    [HttpGet("findAll")]
    public IActionResult FindAll()
    {
        try
        {
            return Ok(blogService.findAll());
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
    // Create New blog
    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPost("create")]
    public IActionResult Create([FromBody] Blog blog)
    {
        try
        {
            return Ok(new
            {
                status = blogService.create(blog)
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }

    // ===============================
    // ============== PUT
    // ===============================

    // Update Information blog
    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPut("update")]
    public IActionResult Update([FromBody] Blog blog)
    {
        try
        {
            blog.UpdatedAt = DateTime.Now;

            return Ok(new
            {
                status = blogService.update(blog)
            });

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
                status = blogService.Delete(id)
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }
}
