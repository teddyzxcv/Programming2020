using System;

class Boat
{
    public bool IsAtThePort { get; set; }

    public int Value { get; set; }
    public Boat(int value, bool isAtThePort)
    {
        this.Value = value;
        this.IsAtThePort = isAtThePort;
    }

    public int CountCost(int weight)
    {
        return weight * this.Value;
    }
}


