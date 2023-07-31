using System;
using System.Collections.Generic;

namespace Semester_3_API_Personal.Models;

public partial class InvoiceStatus
{
    public int InvoiceStatusId { get; set; }

    public string? StatusName { get; set; }

    public string? StatusDescription { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
