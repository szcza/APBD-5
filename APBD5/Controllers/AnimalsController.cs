using APBD5.Exceptions;
using APBD5.Models;
using APBD5.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD5.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private IAnimalService _animalService;

    public AnimalsController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = _animalService.GetAnimals();
        return Ok(animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animalService.GetAnimal(id);
        if (animal == null)
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        try
        {
            _animalService.CreateAnimal(animal);
            return StatusCode(StatusCodes.Status201Created);
        }
        catch (NonUniqueIdException e)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        int status = _animalService.DeleteAnimal(id);
        if (status == 1)
        {
            return NoContent();
        }
        return StatusCode(StatusCodes.Status404NotFound);
    }

    [HttpPut]
    public IActionResult UpdateAnimal(Animal animal)
    {
        int status = _animalService.UpdateAnimal(animal);
        if (status == 1)
        {
            return Ok();
        }

        return StatusCode(StatusCodes.Status404NotFound);
    }
    
}