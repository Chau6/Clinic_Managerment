using System;
using System.Collections.Generic;

namespace Semester_3_API_Personal.Models;

public partial class OrderStatus
{
    public int OrderStatusId { get; set; }

    public string? StatusName { get; set; }

    public string? StatusDescription { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
