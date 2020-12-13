using System;
using System.Collections.Generic;
#pragma warning disable

public class ArchaeologicalFind
{
    public int Index = 0;
    public int Age;
    public int Weight;
    public string Name;
    public ArchaeologicalFind(int age, int weight, string name)
    {
        if (age <= 0)
            throw new ArgumentException("Incorrect age");
        if (weight <= 0)
            throw new ArgumentException("Incorrect weight");
        if (name == "?")
            throw new ArgumentException("Undefined name");
        Age = age;
        Weight = weight;
        Name = name;
    }

    /// <summary>
    /// Добавляет находку в список.
    /// </summary>
    /// <param name="finds">Список находок.</param>
    /// <param name="archaeologicalFind">Находка.</param>
    public static void AddFind(ICollection<ArchaeologicalFind> finds, ArchaeologicalFind archaeologicalFind)
    {
        if (!finds.Contains(archaeologicalFind))
        {
            finds.Add(archaeologicalFind);
        }
        archaeologicalFind.Index = TotalFindsNumber;
        TotalFindsNumber++;
    }
    public static int TotalFindsNumber = 0;

    public override bool Equals(object obj)
    {
        if ((((ArchaeologicalFind)obj).Age == this.Age) && (((ArchaeologicalFind)obj).Name == this.Name) && (((ArchaeologicalFind)obj).Weight == this.Weight))
            return true;
        else
            return false;
    }

    public override string ToString() => $"{this.Index} {this.Name} {this.Age} {this.Weight}";
}