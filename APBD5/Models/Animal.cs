namespace APBD5.Models;

public class Animal
{
    public int IdAnimal { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public double Mass { get; set; }
    public string FurColor { get; set; }
}
public enum Category
{
    DOG, CAT, SOMETHING_ELSE
}