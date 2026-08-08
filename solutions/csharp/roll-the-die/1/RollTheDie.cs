public class Player
{
    public int RollDie() => Random.Shared.Next(1, 19);

    public double GenerateSpellStrength() => Math.Round(Random.Shared.NextDouble() * 100.0, 1);
}
