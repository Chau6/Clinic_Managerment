using System;
using System.Collections.Generic;

namespace Semester_3_API_Personal.Models;

public partial class AccountCoupon
{
    public int CouponId { get; set; }

    public int AccountId { get; set; }

    public string? IsUsed { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Coupon Coupon { get; set; } = null!;
}
