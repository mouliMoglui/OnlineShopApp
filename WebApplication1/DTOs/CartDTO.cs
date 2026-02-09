using System;

namespace WebApplication1.DTOs;

public class CartDTO
{
    public string ProductName { get; set; }
    public int ProductPrice { get; set; }
    public string ProductCategory { get; set; }
    public int Amount;
}