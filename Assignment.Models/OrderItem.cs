﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Models;

[PrimaryKey("OrderId", "ItemId")]
[Table("order_items", Schema = "sales")]
public partial class OrderItem
{
    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Required]
    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Required]
    [Column("product_id")]
    public int ProductId { get; set; }

    [Required]
    [Column("quantity")]
    public int Quantity { get; set; }

    [Required]
    [Column("list_price", TypeName = "decimal(10, 2)")]
    public decimal ListPrice { get; set; }

    [Column("discount", TypeName = "decimal(4, 2)")]
    public decimal Discount { get; set; }

    [ForeignKey("OrderId")]
    //[InverseProperty("OrderItems")]
    public virtual Order Order { get; set; } = null!;

    [ForeignKey("ProductId")]
    //[InverseProperty("OrderItems")]
    public virtual Product Product { get; set; } = null!;
}
