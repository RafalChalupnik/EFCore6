namespace PublisherDomain;

public abstract class Pet
{
    public int PetId { get; set; }
    
    public int HumanId { get; set; }
    
    public string Name { get; set; }
    
    public DateTime DateOfBirth { get; set; }

    public abstract string MakeSound();
}