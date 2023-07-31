using System;
using System.Collections.Generic;

namespace Semester_3_API_Personal.Models;

public partial class ProductImage
{
    public int ImageId { get; set; }

    public string? ImageUrl { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
