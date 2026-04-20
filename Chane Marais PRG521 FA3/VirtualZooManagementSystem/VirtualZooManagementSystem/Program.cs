using System;
using System.Collections.Generic;

// these are the Custom exception for the  feeding errors
public class FeedingException : Exception
{
    public FeedingException(string message) : base(message) { }
}

// Struct for dietary information
public struct DietInfo
{
    private string foodType;
    private int dailyAmount;

    public string FoodType
    {
        get { return foodType; }
        set { foodType = value; }
    }

    public int DailyAmount
    {
        get { return dailyAmount; }
        set
        {
            if (value >= 0)
                dailyAmount = value;
            else
                throw new ArgumentException("Daily amount must be non-negative.");
        }
    }
}

// Enum for the  animal types
public enum AnimalType
{
    Mammal,
    Bird,
    Reptile,
    Amphibian,
    Fish

}

// Enum for food types

public enum FoodType
{
    Meat,
    Vegetation,
    Mixed
}

// Enum for habitat types

public enum HabitatType
{
    Desert,
    Forest,
    Aquatic,
    Arctic,
    Grassland
}

// Abstract class for general animal behaviors
public abstract class Animal
{
    private string name;
    private int age;
    private AnimalType type;
    private DietInfo diet;
    private HabitatType habitat;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 0)
                age = value;
            else
                throw new ArgumentException("Age must be non-negative.");
        }
    }

    public AnimalType Type
    {
        get { return type; }
        set { type = value; }
    }

    public DietInfo Diet
    {
        get { return diet; }
        set { diet = value; }
    }

    public HabitatType Habitat
    {
        get { return habitat; }
        set { habitat = value; }
    }

    public Animal(string name, int age, AnimalType type, DietInfo diet, HabitatType habitat)
    {
        Name = name;
        Age = age;
        Type = type;
        Diet = diet;
        Habitat = habitat;
    }

    // Abstract methods to be implemented by derived classes
    public abstract void Eat(string food);
    public abstract void Move();
    public abstract void Speak();
}

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

public interface IClimbable
{
    void Climb();
}

public interface ISwimmable
{
    void Swim();
}


public interface IFlyable
{
    void Fly();
}

// Lion class implementing Animal, IFeedable, and IMovable
public class Lion : Animal, IFeedable, IMovable
{
    public Lion(string name, int age, AnimalType type, DietInfo diet, HabitatType habitat)
        : base(name, age, type, diet, habitat) { }

    public override void Eat(string food)
    {
        if (Diet.FoodType == food)
            Console.WriteLine($"{Name} the Lion is eating {food}.");
        else
            throw new FeedingException($"{Name} the Lion cannot eat {food}.");
    }

    public override void Move()
    {
        Console.WriteLine($"{Name} the Lion is moving.");
    }

    public override void Speak()
    {
        Console.WriteLine($"{Name} the Lion roars.");
    }

    public void Feed(string food)
    {
        Eat(food);
    }
}


public class Rhino : Animal, IFeedable, IMovable
{
    public Rhino(string name, int age, AnimalType type, DietInfo diet, HabitatType habitat)
        : base(name, age, type, diet, habitat) { }

    public override void Eat(string food)
    {
        if (Diet.FoodType == food)
            Console.WriteLine($"{Name} the Rhino is eating {food}.");
        else
            throw new FeedingException($"{Name} the Rhino cannot eat {food}.");
    }

    public override void Move()
    {
        Console.WriteLine($"{Name} the Rhino is moving.");
    }

    public override void Speak()
    {
        Console.WriteLine($"{Name} the Rhino grunts.");
    }

    public void Feed(string food)
    {
        Eat(food);
    }
}

// Koala class implementing Animal, IFeedable, IMovable, and IClimbable
public class Koala : Animal, IFeedable, IMovable, IClimbable
{
    public Koala(string name, int age, AnimalType type, DietInfo diet, HabitatType habitat)
        : base(name, age, type, diet, habitat) { }

    public override void Eat(string food)
    {
        if (Diet.FoodType == food)
            Console.WriteLine($"{Name} the Koala is eating {food}.");
        else
            throw new FeedingException($"{Name} the Koala cannot eat {food}.");
    }

    public override void Move()
    {
        Console.WriteLine($"{Name} the Koala is moving.");
    }

    public override void Speak()
    {
        Console.WriteLine($"{Name} the Koala makes a sound.");
    }

    public void Feed(string food)
    {
        Eat(food);
    }

    public void Climb()
    {
        Console.WriteLine($"{Name} the Koala is climbing.");
    }
}

class Program
{
    // List to store animals
    static List<Animal> animals = new List<Animal>();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your Virtual Zoo Management System!");
        bool exit = false;
        while (!exit)
        {
            // Display menu options
            Console.WriteLine("\nPlease select an option:");
            Console.WriteLine("1. Add an animal");
            Console.WriteLine("2. Interact with an animal");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        try
                        {
                            AddAnAnimal();
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        InteractWithAnAnimal();
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    // Method to add an animal
    static void AddAnAnimal()
    {
        Console.WriteLine("\nChoose an animal to add:");
        Console.WriteLine("1. Lion");
        Console.WriteLine("2. Rhino");
        Console.WriteLine("3. Koala");
        Console.Write("Enter your choice: ");
        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            Console.Write("Enter animal's name: ");
            string name = Console.ReadLine();
            Console.Write("Enter animal's age: ");
            int age;
            if (int.TryParse(Console.ReadLine(), out age))
            {
                // Get animal type
                Console.WriteLine("Enter animal type:");
                foreach (var type in Enum.GetValues(typeof(AnimalType)))
                {
                    Console.WriteLine($"{(int)type}. {type}");
                }
                int typeChoice;
                if (int.TryParse(Console.ReadLine(), out typeChoice) && Enum.IsDefined(typeof(AnimalType), typeChoice))
                {
                    AnimalType animalType = (AnimalType)typeChoice;

                    // Get diet information
                    Console.WriteLine("Enter diet information:(Meat,Vegetation,Mixed) ");
                    DietInfo dietInfo = GetDietInfo();

                    // Get habitat type
                    Console.WriteLine("Enter habitat type:");
                    HabitatType habitatType = GetHabitatType();

                    // Add animal based on choice
                    switch (choice)
                    {
                        case 1:
                            animals.Add(new Lion(name, age, animalType, dietInfo, habitatType));
                            Console.WriteLine("Lion added successfully!");
                            break;
                        case 2:
                            animals.Add(new Rhino(name, age, animalType, dietInfo, habitatType));
                            Console.WriteLine("Rhino added successfully!");
                            break;
                        case 3:
                            animals.Add(new Koala(name, age, animalType, dietInfo, habitatType));
                            Console.WriteLine("Koala added successfully!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid animal type.");
                }
            }
            else
            {
                Console.WriteLine("Invalid age. Please enter a number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    // Method to get diet information
    static DietInfo GetDietInfo()
    {
        DietInfo dietInfo = new DietInfo();

        Console.Write("Enter food type: ");
        dietInfo.FoodType = Console.ReadLine();

        Console.Write("Enter daily amount (in grams): ");
        int dailyAmount;
        if (int.TryParse(Console.ReadLine(), out dailyAmount))
        {
            dietInfo.DailyAmount = dailyAmount;
        }
        else
        {
            throw new ArgumentException("Invalid daily amount. Please enter a number.");
        }

        return dietInfo;
    }

    // Method to get habitat type
    static HabitatType GetHabitatType()
    {
        foreach (var habitat in Enum.GetValues(typeof(HabitatType)))
        {
            Console.WriteLine($"{(int)habitat}. {habitat}");
        }
        int habitatChoice;
        if (int.TryParse(Console.ReadLine(), out habitatChoice) && Enum.IsDefined(typeof(HabitatType), habitatChoice))
        {
            return (HabitatType)habitatChoice;
        }
        else
        {
            throw new ArgumentException("Invalid habitat type.");
        }
    }

    // Method to interact with an animal
    static void InteractWithAnAnimal()
    {
        if (animals.Count == 0)
        {
            Console.WriteLine("No animals available to interact with.");
            return;
        }

        Console.WriteLine("\nChoose an animal to interact with:");
        for (int i = 0; i < animals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {animals[i].Name} the {animals[i].GetType().Name}");
        }

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= animals.Count)
        {
            Animal animal = animals[choice - 1];

            Console.WriteLine($"\nInteracting with {animal.Name} the {animal.GetType().Name}:");
            animal.Move();
            animal.Speak();

            if (animal is IFeedable feedable)
            {
                Console.Write("Enter the food to feed it: ");
                string food = Console.ReadLine();
                try
                {
                    feedable.Feed(food);
                }
                catch (FeedingException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (animal is IClimbable climbable)
            {
                climbable.Climb();
            }
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }
}

