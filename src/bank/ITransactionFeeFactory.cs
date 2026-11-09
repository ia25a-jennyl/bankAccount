using System;

namespace bank;

public interface ITransactionFeeFactory
{
    public ITransactionFee Create(Enum type);
}