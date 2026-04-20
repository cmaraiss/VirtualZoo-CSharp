using System;
using System.Collections.Generic;

// Interface for feedable animals
public interface IFeedable
{
    void Feed(string food);
}

// Interface for movable animals
public interface IMovable
{
    void Move();
}

// Base class for animals
public class Animal
{
    // Common properties
    public string Name { get; set; }
    public int Age { get; set; }

    // this is a constructor
    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    
    public virtual void Eat(string food)
    {
        Console.WriteLine($"{Name} is eating {food}.");
    }

    // This is a common Method
    public virtual void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping.");
    }

    
    public virtual void Speak()
    {
        Console.WriteLine($"{Name} makes a sound.");
    }
}

// these are the Animal classes
public class Lion  : Animal, IMovable
{
    
    public Lion (string name, int age) : base(name, age)
    {
    }

    // this overides the eat method
    public override void Eat(string food)
    {
        Console.WriteLine($"{Name} the Lion  is eating {food}.");
    }

    // this overides the move method
    public void Move()
    {
        Console.WriteLine($"{Name} the Lion is running .");
    }

    // Override Speak method
    public override void Speak()
    {
        Console.WriteLine($"{Name} the Lion Roars.");
    }
}

public class Rhino : Animal, IMovable
{
    public Rhino(string name, int age) : base(name, age)
    {
    }

    // Overrides Eat method to accept different types of food
    public override void Eat(string food)
    {
        Console.WriteLine($"{Name} the Rhino is eating {food}.");
    }

    public void Move()
    {
        Console.WriteLine($"{Name} the Rhino is Wallowing.");
    }

    public override void Speak()
    {
        Console.WriteLine($"{Name} the Rhino Grunts.");
    }
}

public class Koala : Animal, IFeedable
{
    public Koala(string name, int age) : base(name, age)
    {
    }

    // Implement Feed method
    public void Feed(string food)
    {
        Console.WriteLine($"{Name} the Koala is eating {food}.");
    }

    public override void Speak()
    {
        Console.WriteLine($"{Name} the Koala is Ballowing.");
    }
    public void Move()
    {
        Console.WriteLine($"{Name} the koala is Climbing.");
    }
}

class Program
{
    static List<Animal> animals = new List<Animal>();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your Virtual Zoo Management System!");

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nPlease select an option:");
            Console.WriteLine("1. Please add an animal of your choice");
            Console.WriteLine("2. Interact with an animal");
            Console.WriteLine("3. Exit the Program!!!");
            Console.Write("Please Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddAnAnimal();
                        break;
                    case 2:
                        InteractWithAnAnimal();
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("The Choice is Invalid . Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("You have chosen wrong. Please enter a number.");
            }
        }
    }

    static void AddAnAnimal()
    {
        Console.WriteLine("\nChoose an animal of your liking to add:");
        Console.WriteLine("1. Lion ");
        Console.WriteLine("2. Rhino");
        Console.WriteLine("3. Koala");
        Console.Write("Enter your choice: ");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            Console.Write("Name of your Animal: ");
            string name = Console.ReadLine();
            Console.Write("Age of the animal: ");
            int age;
            if (int.TryParse(Console.ReadLine(), out age))
            {
                switch (choice)
                {
                    case 1:
                        animals.Add(new Lion (name, age));
                        Console.WriteLine("Lion has been added successfully!");
                        break;
                    case 2:
                        animals.Add(new Rhino(name, age));
                        Console.WriteLine("Rhinohas been added successfully!");
                        break;
                    case 3:
                        animals.Add(new Koala(name, age));
                        Console.WriteLine("Koala has been added successfully!");
                        break;
                    default:
                        Console.WriteLine("An Invalid choice has been made.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Age is Invalid. Please enter a number.");
            }
        }
        else
        {
            Console.WriteLine("Input is invalid. Please enter a number.");
        }
    }

    static void InteractWithAnAnimal()
    {
        if (animals.Count == 0)
        {
            Console.WriteLine("There aren't any animals in the zoo.");
            return;
        }

        Console.WriteLine("\nSelect an animal to interact with:");
        for (int i = 0; i < animals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {animals[i].Name}");
        }
        Console.Write("Enter the number of the animal: ");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= animals.Count)
        {
            Animal selectedAnimal = animals[choice - 1];

            Console.WriteLine($"\nInteracting with {selectedAnimal.Name}:");
            Console.WriteLine("1. Feed");
            Console.WriteLine("2. Sleep");
            Console.WriteLine("3. Speak");
            if (selectedAnimal is IMovable)
            {
                Console.WriteLine("4. Move");
            }

            Console.Write("Enter your choice: ");
            int action;
            if (int.TryParse(Console.ReadLine(), out action))
            {
                switch (action)
                {
                    case 1:
                        if (selectedAnimal is IFeedable)
                        {
                            Console.Write("Enter the type of food: ");
                            string food = Console.ReadLine();
                            (selectedAnimal as IFeedable).Feed(food);
                        }
                        else
                        {
                            Console.WriteLine("This animal cannot be fed.");
                        }
                        break;
                    case 2:
                        selectedAnimal.Sleep();
                        break;
                    case 3:
                        selectedAnimal.Speak();
                        break;
                    case 4:
                        if (selectedAnimal is IMovable)
                        {
                            (selectedAnimal as IMovable).Move();
                        }
                        else
                        {
                            Console.WriteLine("This animal cannot move.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}