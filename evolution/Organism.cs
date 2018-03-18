using System;
using System.Linq;

namespace evolution {
public class Organism
{
    const int size = 50;
    const int maxHeight = 500;

    public static int[] CreateShape()
    {
        int[] shape = new int[size];
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            shape[i] = random.Next(maxHeight);
        }
        return shape;
    }

    static int GetMatchIndex(Organism org, int[] terrain)
    {
        int diff = 0;
        var data = org.GetMatchData(terrain);
        for (int i = 0; i < data.Length; i++)
        {
            diff += Math.Abs(maxHeight - data[i]);
        }
        return diff;
    }

    int[] shape;

    public Organism()
    :this(CreateShape())
    { }

    public Organism(int[] shape)
    {
        this.Shape = shape;
    }

    public int[] GetMatchData(int[] terrain)
    {
        int[] total = new int[size];
        for (int i = 0; i < size; i++)
        {
            total[i] = shape[i] + terrain[i];
        }
        return total;
    }

    public int[] Shape {
        get{
        return shape;
    } set{
        shape = value;
    }
    }

    public double GetMatchIndex(int[] terrain)
    {
        return GetMatchIndex(this, terrain);
    }
}
}