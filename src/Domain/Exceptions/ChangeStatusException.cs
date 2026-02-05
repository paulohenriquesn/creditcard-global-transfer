using Domain.Enums;

namespace Domain.Exceptions;

public class ChangeStatusException : Exception
{
    public ChangeStatusException(PaymentStatus newStatus, PaymentStatus currentStatus) : base(
        $"Cannot change status from {currentStatus} to {newStatus}.")
    {
    }
}