using System;
using System.Collections.Generic;

namespace Semester_3_API_Personal.Models;

public partial class BlogReview
{
    public int BlogReviewId { get; set; }

    public int? BlogId { get; set; }

    public int? AccountId { get; set; }

    public string? Content { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Blog? Blog { get; set; }
}
