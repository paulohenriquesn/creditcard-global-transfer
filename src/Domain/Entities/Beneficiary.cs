namespace CreditCardGlobalTransfer.Domain.Entities;

public class Beneficiary
{
    private string Name;
    private string CountryISOCode;
    
    public Beneficiary(string Name, string CountryISOCode)
    {
        this.Name = Name;
        this.CountryISOCode = CountryISOCode;
    }
    
    public string GetName()
    {
        return this.Name;
    }
    
    public string GetCountryISOCode()
    {
        return this.CountryISOCode;
    }
}