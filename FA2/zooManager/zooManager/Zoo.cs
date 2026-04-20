public class Zoo
{
    private List<Animal> animals = new List<Animal>();

    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
    }

    public List<Animal> GetAnimals()
    {
        return animals;
    }

    public void MakeAllAnimalsEat(string food)
    {
        foreach (var animal in animals)
        {
            animal.Eat(food);
        }
    }
}
