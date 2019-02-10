using System;

public interface IBird
{
    Egg Lay();
}

// Should implement IBird
public class Chicken : IBird
{
    public Chicken()
    {
        Console.WriteLine("New Chicken");
    }

    public Egg Lay()
    {
        Console.WriteLine("Egg Layed");
        return new Egg(new Func<Chicken>(() => new Chicken()));
    }
}

public class Egg
{
    bool isHatched = false;
    Func<IBird> create;

    public Egg(Func<IBird> createBird)
    {
        create = createBird;
    }

    public IBird Hatch()
    {
        if (!isHatched)
        {
            Console.WriteLine("Egg Hatched");
            isHatched = true;
            return create();
        }
        else
        {
            throw new InvalidOperationException("Can't hatch an egg twice");
        }

    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var chicken1 = new Chicken();
        var egg = chicken1.Lay();
        var childChicken = egg.Hatch();
    }
}