public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    private static void Validate(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency) 
            throw new ArgumentException("Cannot operate on different currencies.");
    }

    public static bool operator ==(CurrencyAmount left, CurrencyAmount right)
    {
        Validate(left, right);
        return left.amount == right.amount;
    }

    public static bool operator !=(CurrencyAmount left, CurrencyAmount right)
    {
        Validate(left, right);
        return left.amount != right.amount;
    }

    public static bool operator <(CurrencyAmount left, CurrencyAmount right)
    {
        Validate(left, right);
        return left.amount < right.amount;
    }
    
    public static bool operator >(CurrencyAmount left, CurrencyAmount right)
    {
        Validate(left, right);
        return left.amount > right.amount;
    }

    public static decimal operator +(CurrencyAmount left, CurrencyAmount right)
    {
        Validate(left, right);
        return left.amount + right.amount;
    }

    public static decimal operator -(CurrencyAmount left, CurrencyAmount right)
    {
        Validate(left, right);
        return left.amount - right.amount;
    }

    public static decimal operator *(CurrencyAmount left, CurrencyAmount right)
    {
        Validate(left, right);
        return left.amount * right.amount;
    }

    public static decimal operator /(CurrencyAmount left, CurrencyAmount right)
    {
        Validate(left, right);
        if (right.amount == 0) throw new DivideByZeroException();
        return left.amount / right.amount;
    }

    public static explicit operator double(CurrencyAmount value) => (double)value.amount;

    public static implicit operator decimal(CurrencyAmount value) => value.amount;

    public override bool Equals(object obj) => obj is CurrencyAmount other && Equals(other);
    
    public bool Equals(CurrencyAmount other) => currency == other.currency && amount == other.amount;

    public override int GetHashCode() => HashCode.Combine(amount, currency);
}
