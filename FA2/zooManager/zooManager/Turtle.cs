public class Turtle : Animal, IFeedable, IMovable
{
    public Turtle(string name, int age) : base(name, age) { }

    public void Feed()
    {
        Console.WriteLine($"{Name} is being fed lettuce.");
    }

    public void Move()
    {
        Console.WriteLine($"{Name} is crawling slowly.");
    }

    public override void Eat(string food)
    {
        Console.WriteLine($"{Name} is eating lettuce.");
    }
}
