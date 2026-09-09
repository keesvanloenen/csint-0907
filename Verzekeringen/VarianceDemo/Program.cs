namespace VarianceDemo;

interface IJuicer<in T> // contravariant    iN -> coNtravariant
{
    void Juice(T fruit);
}

public class FruitJuicer : IJuicer<Fruit>
{
    public void Juice(Fruit fruit)
    {
        Console.WriteLine($"Juicing a {fruit.Name}");
    }
}

public abstract class Fruit
{
    public required string Name { get; set; }
}

public class Apple : Fruit { }
public class Banana : Fruit { }


internal class Program
{
    static void Main(string[] args)
    {
        List<Apple> apples =
        [
            new Apple { Name = "Braeburn" },
            new Apple { Name = "Jonagold" }
        ];

        ShowFruit(apples);

        IJuicer<Fruit> fruitJuicer = new FruitJuicer();
        JuiceApples(fruitJuicer);
    }

    private static void ShowFruit(IEnumerable<Fruit> fruits)
    {
        foreach(var fruit in fruits)
        {
            Console.WriteLine(fruit.Name);
        }

        //fruits[1] = new Banana { Name = "Chiquita" };
    }

    private static void JuiceApples(IJuicer<Apple> appleJuicer)
    {
        appleJuicer.Juice(new Apple { Name = "Golden Delicious" });
    }
}
