namespace PublisherDomain;

public class Dog : Pet
{
    public decimal BarkDecibels { get; set; }

    public override string MakeSound()
        => $"I bark with {BarkDecibels} dB.";
}