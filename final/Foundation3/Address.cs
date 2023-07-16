public class Address
{
    private string _streetAddress;
    private string _city;
    private string _province;
    private string _country;
    public Address(string streetAddress, string city, string province, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _province = province;
        _country = country;
    }
    public string GetAddress()
    {
        return $"{_streetAddress}, {_city}, {_province}, {_country}";
    }


}