using APBD5.Exceptions;
using APBD5.Models;
using APBD5.Repositories;

namespace APBD5.Services;

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }
    public IEnumerable<Animal> GetAnimals()
    {
        return _animalRepository.GetAnimals();
    }

    public Animal? GetAnimal(int animalId)
    {
        return _animalRepository.GetAnimal(animalId);
    }

    public int CreateAnimal(Animal animal)
    {
        var enumerable = _animalRepository.GetAnimals();
        foreach (var an in enumerable)
        {
            if (an.IdAnimal == animal.IdAnimal)
            {
                throw new NonUniqueIdException();
            }
        }
        return _animalRepository.CreateAnimal(animal);
    }

    public int UpdateAnimal(Animal animal)
    {
        return _animalRepository.UpdateAnimal(animal);
    }

    public int DeleteAnimal(int animalId)
    {
        
        return _animalRepository.DeleteAnimal(animalId);
    }
}