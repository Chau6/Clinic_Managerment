using System;
using System.Collections.Generic;

namespace Semester_3_API_Personal.Models;

public partial class Invoice
{
    public int CartId { get; set; }

    public int? AccountId { get; set; }

    public int? PaymentId { get; set; }

    public int? InvoiceStatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Account? Account { get; set; }

    public virtual InvoiceStatus? InvoiceStatus { get; set; }

    public virtual PaymentMethod? Payment { get; set; }
}
