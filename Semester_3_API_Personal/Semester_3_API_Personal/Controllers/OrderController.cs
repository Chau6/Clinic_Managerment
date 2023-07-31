using Microsoft.AspNetCore.Mvc;
using Semester_3_API_Personal.Helpers;
using Semester_3_API_Personal.Models;
using Semester_3_API_Personal.Service;
using System.Diagnostics;

namespace Semester_3_API_Personal.Controllers;
[Route("api/admin/order")]
public class OrderController : Controller
{
    private OrderService orderService;
    private OrderDetailService orderDetailService;

    public OrderController(OrderService orderService, OrderDetailService orderDetailService)
    {
        this.orderService = orderService;
        this.orderDetailService = orderDetailService;
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
            return Ok(orderService.findAll());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }

    // Find Order Detail
    [Produces("application/json")]
    [HttpGet("findOrderDetail/{id}")]
    public IActionResult FindOrderDetail(int id)
    {
        try
        {
            return Ok(orderDetailService.findOrderDetail(id));
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
    // Create New Order
    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPost("create")]
    public IActionResult Create([FromBody] Order Order)
    {
        try
        {
            return Ok(new
            {
                status = orderService.create(Order)
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

    // Update Information Order
    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPut("update")]
    public IActionResult Update([FromBody] Order Order)
    {
        try
        {
            Order.UpdatedAt = DateTime.Now;

            return Ok(new
            {
                status = orderService.update(Order)
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
                status = orderService.Delete(id)
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }
}
