using CreditCardGlobalTransfer.Domain.Entities;
using FluentAssertions;

namespace Tests.Domain.Entities;

public class BeneficiaryTests
{
    internal Beneficiary makeEntity()
    {
        return new Beneficiary("Test", "BR");
    }
    
    [Fact]
    public void Should_Create_With_Valid_Name()
    {
        var entity = makeEntity();

        entity.GetName().Should().Be("Test");
    }
    
    [Fact]
    public void Should_Create_With_Valid_Country()
    {
        var entity = makeEntity();

        entity.GetCountryISOCode().Should().Be("BR");
    }
}