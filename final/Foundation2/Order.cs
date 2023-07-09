public class Order
{
    private List<Product> _listOfProducts;
    private Customer _customer;
    private double _shipCost;
    private double _totalCost;
    private string _packingLabel;
    private string _shippingLabel;
    public Order(Customer customer)
    {
        _customer = customer;
        _listOfProducts = new List<Product>();
    }
    public void ComputeSubTotalPrice()
    {
        foreach(Product product in _listOfProducts)
        {
            _totalCost += product.GetTotalPrice();
        }
        AddShipCost();
        CreatePackingLabel();
        CreateShippingLabel();
    }
    public void DisplayTotalCost()
    {
        Console.WriteLine($"\nSubTotal: $ {_totalCost}");
        Console.WriteLine($"Ship Cost: $ {_shipCost}");
        Console.WriteLine($"Total: ${_totalCost + _shipCost}\n");
    }
    public void AddProduct(string name, string productId, double price, int quantity)
    {
        Product product = new Product(name, productId, price, quantity);
        _listOfProducts.Add(product);
    }
    private void AddShipCost()
    {
        bool inUsa = _customer.GetIsUsa();
        if(inUsa)
        {
            _shipCost = 5.0;
        }
        else
        {
            _shipCost = 35.0;
        }
    }
    private void CreatePackingLabel()
    {
        _packingLabel += "PRODUCTS:\n";
        foreach(Product product in _listOfProducts)
        {
            _packingLabel += $"- {product.GetProductId()} - {product.GetName()} - ${Math.Round(product.GetTotalPrice(), 2)}\n";
        }
    }
    private void CreateShippingLabel()
    {
        _shippingLabel = $"ADDRESS:\n{_customer.GetName()}\n{_customer.GetAddress()}";
    }
    public string GetPackingLabel()
    {
        return _packingLabel;
    }
    public string GetShippingLabel()
    {
        return _shippingLabel;
    }
}