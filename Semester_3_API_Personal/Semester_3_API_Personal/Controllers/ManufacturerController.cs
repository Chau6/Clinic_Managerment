using Microsoft.AspNetCore.Mvc;
using Semester_3_API_Personal.Models;
using Semester_3_API_Personal.Service;
using System.Diagnostics;

namespace Semester_3_API_Personal.Controllers;
[Route("api/manufacture")]
public class ManufacturerController : Controller
{
    private ManufacturerService manufacturerService;
    private IWebHostEnvironment webHostEnvironment;

    public ManufacturerController(ManufacturerService manufacturerService, IWebHostEnvironment webHostEnvironment)
    {
        this.manufacturerService = manufacturerService;
        this.webHostEnvironment = webHostEnvironment;
    }

    [Produces("application/json")]
    [HttpGet("findAll")]
    public IActionResult findAll()
    {
        try
        {
            return Ok(manufacturerService.findAll());
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
            return Ok(manufacturerService.find(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpPost("create")]
    public IActionResult Create([FromBody] Manufacturer manufacturer)
    {
        try
        {
            return Ok(new
            {
                status = manufacturerService.Create(manufacturer)
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
    public IActionResult Edit([FromBody] Manufacturer manufacturer)
    {
        try
        {
            return Ok(new
            {
                status = manufacturerService.Edit(manufacturer)
            });
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
                status = manufacturerService.Delete(id)
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }
}
