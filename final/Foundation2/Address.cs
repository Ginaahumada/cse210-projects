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
    public bool IsUSA()
    {
        if(_country == "USA" || _country == "United States")
        {
            return true;
        }
        return false;
    }
    public string CreateAddress()
    {
        return $"{_streetAddress}\n{_city}\n{_province}\n{_country.ToUpper()}";
    }

}