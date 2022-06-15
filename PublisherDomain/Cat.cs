namespace PublisherDomain;

public class Cat : Pet
{
    public int Meows { get; set; }

    public override string MakeSound()
        => $"I meow {Meows} times.";
}