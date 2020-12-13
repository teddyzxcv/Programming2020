using System;

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public int Z { get; set; }

    public Point(int x, int y, int z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public override bool Equals(object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            Point p = (Point)obj;
            return (this.X == p.X) && (this.Y == p.Y) && (this.Z == p.Z);
        }
    }

    public override int GetHashCode()
    {
        var hash = 17;
        hash = hash * 31 + this.X.GetHashCode();
        hash = hash * 31 + this.Y.GetHashCode();
        return hash;
    }

    public override string ToString() => $"{this.X} {this.Y} {this.Z}";
}