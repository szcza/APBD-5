using APBD5.Models;

namespace APBD5.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private static List<Animal> _animals;

    public AnimalRepository()
    {
        _animals = new List<Animal>();
    }
    public IEnumerable<Animal> GetAnimals()
    {
        return _animals;
    }

    public Animal GetAnimal(int animalId)
    {
        foreach (var animal in _animals)
        {
            if (animalId == animal.IdAnimal)
                return animal;
        }

        return null;
    }

    public int CreateAnimal(Animal animal)
    {
        _animals.Add(animal);
        return 1;
    }

    public int UpdateAnimal(Animal animal)
    {
        foreach (var animalInRepo in _animals)
        {
            if (animalInRepo.IdAnimal == animal.IdAnimal)
            {
                animalInRepo.Category = animal.Category;
                animalInRepo.Name = animal.Name;
                animalInRepo.FurColor = animal.FurColor;
                animalInRepo.Mass = animal.Mass;
                return 1;
            }
        }

        return 0;
    }

    public int DeleteAnimal(int animalId)
    {
        foreach (var animal in _animals)
        {
            if (animal.IdAnimal == animalId)
            {
                _animals.Remove(animal);
                return 1;
            }
        }

        return 0;
    }
}