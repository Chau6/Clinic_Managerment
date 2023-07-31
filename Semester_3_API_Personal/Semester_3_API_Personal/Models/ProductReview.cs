using System;
using System.Collections.Generic;

namespace Semester_3_API_Personal.Models;

public partial class ProductReview
{
    public int ProductReviewId { get; set; }

    public int? ProductId { get; set; }

    public int? AccountId { get; set; }

    public string? Content { get; set; }

    public byte? Rating { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Product? Product { get; set; }
}
