namespace TrumpCardProject;

public class Deck
{
    private List<Card> cards = new List<Card>();
    private List<string> fieldNames = new List<string> { "attack", "defence", "speed", "strength", "height", "weight" };
    public Deck()
    {
        Random generator = new Random();
        for (int i = 0; i < 36; i++)
        {
            List<int> values = new List<int>();


            for (int j = 0; j < 6; j++)
            {
                values.Add(generator.Next(0, 100 + 1));
            }

            Card c = new Card(values);
            cards.Add(c);
        }
    }

    public Card getCard(int ind)
    {
        return cards[ind];
    }
    public int getDeckLength()
    {
        return cards.Count;
    }

    public string getFieldName(int ind)
    {
        return fieldNames[ind];
    }

    public int getNumOfFields()
    {
        return fieldNames.Count();
    }

    public void shuffle()
    {
        return;
    }
}