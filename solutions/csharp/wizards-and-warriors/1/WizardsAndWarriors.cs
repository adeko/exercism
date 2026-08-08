abstract class Character
{
    public string CharacterType { get; set; }
    public bool IsVulnerable { get; set; } = false;
    
    protected Character(string characterType)
    {
        CharacterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return IsVulnerable;
    }

    public override string ToString()
    {
        return "Character is a " + CharacterType;
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    public bool HasPreparedSpell { get; set; } = false;
    
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        return HasPreparedSpell ? 12 : 3;
    }

    public override bool Vulnerable()
    {
        return !HasPreparedSpell || IsVulnerable;
    }

    public void PrepareSpell()
    {
        HasPreparedSpell = true;
    }
}
