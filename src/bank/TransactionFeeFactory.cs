using System;

namespace bank;


public class TransactionFeeFactory : ITransactionFeeFactory
{
    public ITransactionFee Create(Enum type)
    {
        switch (type)
        {
            case TransactionFeeType.Small:
                return new SmallTransactionFee();
            case TransactionFeeType.Medium:
                return new MediumTransactionFee();
            case TransactionFeeType.Large:
                return new LargeTransactionFee();
            default:
                throw new ArgumentException("Invalid TransactionFeeType");
        }
    }
}   