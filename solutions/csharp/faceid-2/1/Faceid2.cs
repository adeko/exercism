public class FacialFeatures : IEquatable<FacialFeatures>
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    
    public bool Equals(FacialFeatures? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return EyeColor == other.EyeColor && PhiltrumWidth == other.PhiltrumWidth;
    }

    public override bool Equals(object? obj) => Equals(obj as FacialFeatures);
    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public class Identity: IEquatable<Identity>
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    
    public bool Equals(Identity? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Email == other.Email && Equals(FacialFeatures, other.FacialFeatures);
    }

    public override bool Equals(object? obj) => Equals(obj as Identity);
    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
    HashSet<Identity> RegisteredIdentities { get; set; } = [];
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => Equals(faceA, faceB);
    
    public bool IsAdmin(Identity identity) => Equals(new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m)), identity);
    
    public bool Register(Identity identity) => RegisteredIdentities.Add(identity);
    
    public bool IsRegistered(Identity identity) => RegisteredIdentities.Contains(identity);
    
    public static bool AreSameObject(Identity identityA, Identity identityB) => ReferenceEquals(identityA, identityB);
}
