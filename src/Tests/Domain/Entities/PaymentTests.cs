using CreditCardGlobalTransfer.Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace Tests.Domain.Entities;

public class PaymentTests
{
    internal Beneficiary makeBeneficiary()
    {
        return new Beneficiary("Test Beneficiary", "BR");
    }

    internal Payment makeEntity()
    {
        return new Payment(makeBeneficiary());
    }

    [Fact]
    public void Should_Create_With_Pending_Status()
    {
        var entity = makeEntity();

        entity.GetStatus().Should().Be(PaymentStatus.PENDING);
    }

    [Fact]
    public void Should_Have_CreatedAt_Date()
    {
        var beforeCreation = DateTime.Now;
        var entity = makeEntity();
        var afterCreation = DateTime.Now;

        entity.GetCreatedAt().Should().BeOnOrAfter(beforeCreation);
        entity.GetCreatedAt().Should().BeOnOrBefore(afterCreation);
    }

    [Fact]
    public void Should_Set_And_Get_Url()
    {
        var entity = makeEntity();
        var url = "https://payment.example.com/12345";

        entity.SetUrl(url);

        entity.GetUrl().Should().Be(url);
    }

    [Fact]
    public void Should_Change_Status_From_Pending_To_Completed()
    {
        var entity = makeEntity();

        entity.SetStatus(PaymentStatus.COMPLETED);

        entity.GetStatus().Should().Be(PaymentStatus.COMPLETED);
    }

    [Fact]
    public void Should_Change_Status_From_Pending_To_Failed()
    {
        var entity = makeEntity();

        entity.SetStatus(PaymentStatus.FAILED);

        entity.GetStatus().Should().Be(PaymentStatus.FAILED);
    }

    [Fact]
    public void Should_Not_Change_Status_When_Setting_Pending_To_Pending()
    {
        var entity = makeEntity();

        entity.SetStatus(PaymentStatus.PENDING);

        entity.GetStatus().Should().Be(PaymentStatus.PENDING);
    }

    [Fact]
    public void Should_Throw_Exception_When_Changing_Status_From_Completed()
    {
        var entity = makeEntity();
        entity.SetStatus(PaymentStatus.COMPLETED);

        var act = () => entity.SetStatus(PaymentStatus.FAILED);

        act.Should().Throw<ChangeStatusException>()
            .WithMessage("Cannot change status from COMPLETED to FAILED.");
    }

    [Fact]
    public void Should_Throw_Exception_When_Changing_Status_From_Failed()
    {
        var entity = makeEntity();
        entity.SetStatus(PaymentStatus.FAILED);

        var act = () => entity.SetStatus(PaymentStatus.COMPLETED);

        act.Should().Throw<ChangeStatusException>()
            .WithMessage("Cannot change status from FAILED to COMPLETED.");
    }

    [Fact]
    public void Should_Throw_Exception_When_Changing_Completed_To_Pending()
    {
        var entity = makeEntity();
        entity.SetStatus(PaymentStatus.COMPLETED);

        var act = () => entity.SetStatus(PaymentStatus.PENDING);

        act.Should().Throw<ChangeStatusException>()
            .WithMessage("Cannot change status from COMPLETED to PENDING.");
    }

    [Fact]
    public void Should_Throw_Exception_When_Changing_Failed_To_Pending()
    {
        var entity = makeEntity();
        entity.SetStatus(PaymentStatus.FAILED);

        var act = () => entity.SetStatus(PaymentStatus.PENDING);

        act.Should().Throw<ChangeStatusException>()
            .WithMessage("Cannot change status from FAILED to PENDING.");
    }
}