using Shopping.API.Models;

namespace Shopping.API.Data;

public static class ProductContext
{
    public static readonly List<Product> Products = new List<Product>
    {
        new Product()
        { 
            Name="IPhone X",
            Description="Test Description for Iphone X",
            ImageFile="product-1.png",
            Price=950.00M,
            Category="Smart Phone"
        },
        new Product()
        {
            Name="Samsung 10",
            Description="Test Description for Samsung 10",
            ImageFile="product-2.png",
            Price=840.00M,
            Category="Smart Phone"
        },
        new Product()
        {
            Name="Huawei Plue",
            Description="Test Description for Huawei Plue",
            ImageFile="product-3.png",
            Price=650.00M,
            Category="Smart Phone"
        },
        new Product()
        {
            Name="Xiaomi Mi 9",
            Description="Test Description for Xiaomi Mi 9",
            ImageFile="product-4.png",
            Price=470.00M,
            Category="White Appliances"
        },
        new Product()
        {
            Name="HTC U11+ Plus",
            Description="Test Description for HTC U11+ Plus",
            ImageFile="product-5.png",
            Price=380.00M,
            Category="Smart Phone"
        },
        new Product()
        {
            Name="LG G7 ThinQ New 8",
            Description="Test Description for LG G7 ThinQ New 8",
            ImageFile="product-6.png",
            Price=240.00M,
            Category="Home Kitchen"
        }

    };
}
