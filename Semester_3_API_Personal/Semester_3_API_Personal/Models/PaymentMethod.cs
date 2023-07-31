using System;
using System.Collections.Generic;

namespace Semester_3_API_Personal.Models;

public partial class PaymentMethod
{
    public int PaymentId { get; set; }

    public string? PaymentName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
