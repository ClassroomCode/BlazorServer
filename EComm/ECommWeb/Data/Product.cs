﻿using System.ComponentModel.DataAnnotations;

namespace ECommWeb.Data;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Product must have a name")]
    public string ProductName { get; set; } = string.Empty;

    [Range(1, 5000)]
    public decimal? UnitPrice { get; set; }

    public string? Package { get; set; }
    public bool IsDiscontinued { get; set; }

    public int SupplierId { get; set; }
    public Supplier? Supplier { get; set; }
}
