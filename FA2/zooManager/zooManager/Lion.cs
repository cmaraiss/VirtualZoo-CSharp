public class Lion : Animal, IFeedable, IMovable
{
    public Lion(string name, int age) : base(name, age) { }

    public void Feed()
    {
        Console.WriteLine($"{Name} is being fed.");
    }

    public void Move()
    {
        Console.WriteLine($"{Name} is moving.");
    }

    public override void Eat(string food)
    {
        Console.WriteLine($"{Name} is eating meat.");
    }
}

