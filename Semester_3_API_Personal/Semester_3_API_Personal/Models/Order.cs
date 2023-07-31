using System;
using System.Collections.Generic;

namespace Semester_3_API_Personal.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? AccountId { get; set; }

    public decimal? TotalPrice { get; set; }

    public int? OrderStatusId { get; set; }

    public int? PaymentId { get; set; }

    public int? CouponId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Coupon? Coupon { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual OrderStatus? OrderStatus { get; set; }

    public virtual PaymentMethod? Payment { get; set; }
}
