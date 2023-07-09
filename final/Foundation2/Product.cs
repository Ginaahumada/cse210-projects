public class Product
{
    private string _name;
    private string _productId;
    private double _individualPrice;
    private double _quantityPrice;
    private int _quantity;
    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _individualPrice = price;
        _quantity = quantity;
        CumputeTotalPriceProduct();
    }
    private void CumputeTotalPriceProduct()
    {
        _quantityPrice = _individualPrice * _quantity;
    }
    public double GetTotalPrice()
    {
        return _quantityPrice;
    }
    public string GetName()
    {
        return _name;
    }
    public string GetProductId()
    {
        return _productId;
    }
}