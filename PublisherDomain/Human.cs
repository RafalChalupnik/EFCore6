namespace PublisherDomain;

public class Human
{
    public int HumanId { get; set; }
    
    public string Name { get; set; }
    
    public List<Pet> Pets { get; set; }
}