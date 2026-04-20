var zoo = new Zoo();

Console.WriteLine("=== Zoo Manager ===\n");

var lion = new Lion("Simba", 5);
var parrot = new Parrot("Polly", 3);
var turtle = new Turtle("Shelly", 20);

zoo.AddAnimal(lion);
zoo.AddAnimal(parrot);
zoo.AddAnimal(turtle);

Console.WriteLine("Animals in the zoo:");
foreach (var animal in zoo.GetAnimals())
{
    Console.WriteLine($"  - {animal.Name} (Age: {animal.Age})");
}

Console.WriteLine("\nFeeding all animals:");
zoo.MakeAllAnimalsEat("food");

Console.WriteLine("\nMoving animals:");
lion.Move();

Console.WriteLine("\nPutting animals to sleep:");
foreach (var animal in zoo.GetAnimals())
{
    animal.Sleep();
}
