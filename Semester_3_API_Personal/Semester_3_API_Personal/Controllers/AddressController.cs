using Microsoft.AspNetCore.Mvc;
using Semester_3_API_Personal.Service;
using System.Diagnostics;

namespace Semester_3_API_Personal.Controllers;
[Route("api/admin/address")]
public class AddressController : Controller
{
    private AddressService addressService;
    private IWebHostEnvironment webHostEnvironment;
    private IConfiguration configuration;

    public AddressController(AddressService addressService, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
    {
        this.addressService = addressService;
        this.webHostEnvironment = webHostEnvironment;
        this.configuration = configuration;
    }

    [Produces("application/json")]
    [HttpGet("findWardsByDistrict/{district}")]
    public IActionResult FindWardsByDistrict(string district)
    {
        try
        {
            return Ok(addressService.findWardsByDistrict(district));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpGet("findDistrictByProvince/{province}")]
    public IActionResult FindDistrictByProvince(string province)
    {
        try
        {
            return Ok(addressService.findDistrictByProvince(province));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpGet("findAllProvince")]
    public IActionResult FindAllProvince()
    {
        try
        {
            return Ok(addressService.findAllProvince());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }
}
