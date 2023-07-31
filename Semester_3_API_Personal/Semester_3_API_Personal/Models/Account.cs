using System;
using System.Collections.Generic;

namespace Semester_3_API_Personal.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public string? Gender { get; set; }

    public int? AddressId { get; set; }

    public string? Avatar { get; set; }

    public int? RoleId { get; set; }

    public bool? Status { get; set; }

    public string? SecurityCode { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? NewGender { get; set; }

    public virtual ICollection<AccountCoupon> AccountCoupons { get; set; } = new List<AccountCoupon>();

    public virtual Address? Address { get; set; }

    public virtual ICollection<BlogReview> BlogReviews { get; set; } = new List<BlogReview>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
}
