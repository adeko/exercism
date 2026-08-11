public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool operator ==(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency) throw new ArgumentException();
        return Equals(left, right);
    }

    public static bool operator !=(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency) throw new ArgumentException();
        return !Equals(left, right);
    }

    public static bool operator <(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency) throw new ArgumentException();
        return (left.amount < right.amount);
    }
    
    public static bool operator >(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency) throw new ArgumentException();
        return (left.amount > right.amount);
    }

    public static decimal operator +(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency) throw new ArgumentException();
        return left.amount + right.amount;
    }

    public static decimal operator -(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency) throw new ArgumentException();
        return left.amount - right.amount;
    }

    public static decimal operator *(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency) throw new ArgumentException();
        return left.amount * right.amount;
    }

    public static decimal operator /(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency) throw new ArgumentException();
        if (right.amount == 0) throw new DivideByZeroException();
        return left.amount / right.amount;
    }

    public static explicit operator double(CurrencyAmount left) => (double)left.amount;

    public static implicit operator decimal(CurrencyAmount left) => left.amount;
}
