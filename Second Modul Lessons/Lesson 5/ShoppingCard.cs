namespace Lesson_5;

public class ShoppingCard : Product
{
    private List<Product> _products;

    public ShoppingCard()
    {
        _products = new List<Product>();
    }

    public Product AddToCard(Product product)
    {
        _products.Add(product);
        return product;

    }
    public double CostToProduct()
    {
        var totalPrice = 0d;
        foreach (var product in _products)
        {
            totalPrice += product.Price * product.Stock;
        }
        return totalPrice;
    }
}
