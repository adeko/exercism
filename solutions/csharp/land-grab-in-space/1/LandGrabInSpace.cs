public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
    {
        Coord1 = coord1;
        Coord2 = coord2;
        Coord3 = coord3;
        Coord4 = coord4;
    }

    public Coord Coord1 { get; }
    public Coord Coord2 { get; }
    public Coord Coord3 { get; }
    public Coord Coord4 { get; }
}


public class ClaimsHandler
{
    public List<Plot> Claims { get; set; } = [];
    
    public void StakeClaim(Plot plot)
    {
        Claims.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        return Claims.Contains(plot);
    }

    public bool IsLastClaim(Plot plot)
    {
        return Equals(Claims.LastOrDefault(), plot);
    }

    public Plot GetClaimWithLongestSide()
    {
        Plot longest = Claims[0];
        int longestSide = 0;

        foreach (var plot in Claims)
        {
            int width = Math.Abs((int)plot.Coord1.X - plot.Coord2.X);
            int height = Math.Abs((int)plot.Coord1.Y - plot.Coord3.Y);
            int sideMax = Math.Max(width, height);
    
            if (sideMax > longestSide)
            {
                longestSide = sideMax;
                longest = plot;
            }
        }

        return longest;
    }
}
