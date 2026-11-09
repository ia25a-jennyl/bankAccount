using System;
using bank._test;

namespace bank;


public class TestTransactionFeeFactory : ITransactionFeeFactory
{
    public ITransactionFee Create(Enum type)
    {
        switch (type)
        {
            case TestTransactionFeeType.Small:
                return new SmallTransactionFee();
            case TestTransactionFeeType.Medium:
                return new MediumTransactionFee();
            case TestTransactionFeeType.Large:
                return new LargeTransactionFee();
            case TestTransactionFeeType.Zero:
                return new ZeroTransacionFee();
            default:
                throw new ArgumentException("Invalid TestTransactionFeeType");
        }
    }
}   