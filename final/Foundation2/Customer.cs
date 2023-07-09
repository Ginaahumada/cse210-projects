public class Customer
{
    private string _name;
    private Address _address;
    public Customer(string name, string streetAddress, string city, string province, string country)
    {
        _name = name;
        Address address = new Address(streetAddress, city, province, country);
        _address = address;
    }
    public bool GetIsUsa()
    {
        return _address.IsUSA();
    }
    public string GetName()
    {
        return _name;
    }
    public string GetAddress()
    {
        return _address.CreateAddress();
    }
}