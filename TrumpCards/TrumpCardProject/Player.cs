namespace TrumpCardProject;

public class Player
{
    private Queue hand = new Queue();
    protected Deck deck;
    private bool playing = true;
    public Player(Deck d)
    {
        deck = d;
    }

    public virtual int chooseField()
    { 
        Console.WriteLine("\nHere is your card"); 
        displayTopCard(); 
        Console.WriteLine("\nenter field number for value to be taken from"); 
        int field = Convert.ToInt32(Console.ReadLine()) - 1; 
        return field;
    }
    private void displayTopCard()
    {
        
        for (int i = 0; i < deck.getNumOfFields(); i++)
        { 
            Console.WriteLine($"{i + 1}. {deck.getFieldName(i)}: {hand.peek().Data.GetFieldVal(i)}");
        }
    }

    public Card placeCard()
    {
        return hand.remove().Data;
    }

    public void pickUp(List<Card> placed)
    {
        foreach (Card card in placed)
        {
            hand.add(card);
        }
    }
    public void pickUp(Card card)
    {
        hand.add(card);
    }

    public int numCards()
    {
        return hand.getLength();
    }

    public bool getPlaying()
    {
        return playing;
    }
    public void outOfGame()
    {
        playing = false;
    }
}