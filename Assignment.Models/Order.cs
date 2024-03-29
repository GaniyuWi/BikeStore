﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Models;

[Table("orders", Schema = "sales")]
public partial class Order
{
    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }
    [Required]
    [Column("customer_id")]
    public int? CustomerId { get; set; }

    [Required]
    [Column("order_status")]
    public byte OrderStatus { get; set; }

    [Column("order_date", TypeName = "date")]
    public DateTime OrderDate { get; set; }

    [Required]
    [Column("required_date", TypeName = "date")]
    public DateTime RequiredDate { get; set; }

    [Column("shipped_date", TypeName = "date")]
    public DateTime? ShippedDate { get; set; }

    [Required]
    [Column("store_id")]
    public int StoreId { get; set; }

    [Required]
    [Column("staff_id")]
    public int StaffId { get; set; }

    [ForeignKey("CustomerId")]
    //[InverseProperty("Orders")]
    //[ValidateNever]
    public virtual Customer Customer { get; set; }

    //[InverseProperty("Order")]
    //public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [ForeignKey("StaffId")]
    //[InverseProperty("Orders")]
    //[ValidateNever]
    public virtual Staff Staff { get; set; } = null!;

    [ForeignKey("StoreId")]
    //[InverseProperty("Orders")]
    //[ValidateNever]
    public virtual Store Store { get; set; } = null!;
}
