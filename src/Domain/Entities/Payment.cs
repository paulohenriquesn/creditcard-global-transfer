using Domain.Enums;
using Domain.Exceptions;

namespace CreditCardGlobalTransfer.Domain.Entities;

public class Payment
{
    private string Url;
    private PaymentStatus Status = PaymentStatus.PENDING;
    private Beneficiary Beneficiary;
    private DateTime CreatedAt = DateTime.Now;

    public Payment(Beneficiary beneficiary)
    {
        this.Beneficiary = beneficiary;
    }

    public void SetStatus(PaymentStatus status)
    {
        if (this.Status == PaymentStatus.PENDING && status == PaymentStatus.PENDING)
        {
            return;
        }

        if (this.Status == PaymentStatus.COMPLETED || this.Status == PaymentStatus.FAILED)
        {
            throw new ChangeStatusException(status, this.Status);
        }
        this.Status = status;
    }
    
    public PaymentStatus GetStatus()
    {
        return this.Status;
    }

    public void SetUrl(string url)
    {
        this.Url = url;
    }

    public string GetUrl()
    {
        return this.Url;
    }

    public DateTime GetCreatedAt()
    {
        return this.CreatedAt;
    }
}