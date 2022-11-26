namespace TrumpCardProject;

public class Computer : Player
{
    public Computer(Deck d) : base(d){}
    public override int chooseField()
    {
        Random generator = new Random();
        int field = generator.Next(0, deck.getNumOfFields());
        return field;
    }
}