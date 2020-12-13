using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public partial class Program
{
    /// <summary>
    /// Считывает точки в список.
    /// </summary>
    /// <returns>Список точек.</returns>
    private static List<Point> GetPoints()
    {
        List<string> InputList = new List<string>(File.ReadAllLines(InputPath));
        List<Point> OutputList = new List<Point>();
        for (int i = 0; i < InputList.Count; i++)
        {
            string[] coord = InputList[i].Split(' ');
            Point p = new Point(int.Parse(coord[0]), int.Parse(coord[1]), int.Parse(coord[2]));
            OutputList.Add(p);
        }
        return OutputList;
    }


    /// <summary>
    /// Получает коллекцию уникальных точек.
    /// </summary>
    /// <param name="points">Список исходных точек.</param>
    /// <returns>Коллекция точек.</returns>
    private static HashSet<Point> GetUnique(List<Point> points)
    {
        points = points.Distinct().ToList();
        return points.ToHashSet();
    }
}