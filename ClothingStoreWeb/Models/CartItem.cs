namespace ClothingStoreWeb.Models;

public class CartItem
{
    public int Product_Id { get; set; }

    public string Product_Name { get; set; } = string.Empty;

    public int Size_Id { get; set; }

    public string Size_Name { get; set; } = string.Empty;

    public decimal Product_Price { get; set; }

    public int Quantity { get; set; }

    public int AvailableQuantity { get; set; }

    public string? Product_ImagePath { get; set; }

    public decimal TotalPrice => Product_Price * Quantity;
}