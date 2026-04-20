public class Parrot : Animal, IFeedable, IMovable
{
    public Parrot(string name, int age) : base(name, age) { }

    public void Feed()
    {
        Console.WriteLine($"{Name} is being fed seeds.");
    }

    public void Move()
    {
        Console.WriteLine($"{Name} is flying.");
    }

    public override void Eat(string food)
    {
        Console.WriteLine($"{Name} is eating seeds.");
    }
}
