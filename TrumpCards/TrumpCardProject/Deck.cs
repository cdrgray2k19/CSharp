using System.Security.Cryptography;

namespace TrumpCardProject;

public class Deck
{
    public List<Card> cards = new List<Card>();
    private List<string> fieldNames = new List<string> { "attack", "defence", "speed", "strength", "height", "weight" };
    private List<int> fieldRanges = new List<int> {50, 50, 30, 10, 7, 100};
    public Deck()
    {
        Random generator = new Random();
        for (int i = 0; i < 36; i++)
        {
            List<int> values = new List<int>();


            for (int j = 0; j < 6; j++)
            {
                values.Add(generator.Next(0, fieldRanges[j]+1));
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
        return fieldNames.Count;
    }

    public List<Card> shuffle(List<Card> arr, int numTimes, int order = 0)
    {
        if (order == numTimes)
        {
            return arr;
        }
        Random generator = new Random();
        int mid = generator.Next(13, 23);
        List<Card> left = splitDeck(cards, 0, mid);
        List<Card> right = splitDeck(cards, mid, cards.Count);
        List<Card> shuffledDeck = new List<Card>();
        while (left.Count > 0 & right.Count > 0)
        {
            int indicator = generator.Next(0, 2);
            if (indicator == 0)
            {
                int numToAdd = Math.Min(generator.Next(1, 4), left.Count);
                for (int _ = 0; _ < numToAdd; _++)
                {
                    shuffledDeck.Add(left[left.Count - 1]);
                    left.RemoveAt(left.Count - 1);
                }
            }
            else
            {
                int numToAdd = Math.Min(generator.Next(1, 4), right.Count);
                for (int _ = 0; _ < numToAdd; _++)
                {
                    shuffledDeck.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            
        }

        if (left.Count > 0)
        {
            int repeats = left.Count;
            for (int _ = 0; _ < repeats; _++)
            {
                shuffledDeck.Add(left[left.Count - 1]);
                left.RemoveAt(left.Count - 1);
            }
        }
        if (right.Count > 0)
        {
            int repeats = right.Count;
            for (int _ = 0; _ < repeats; _++)
            {
                shuffledDeck.Add(right[0]);
                right.RemoveAt(0);
            }
        }

        return shuffle(shuffledDeck, numTimes, order + 1);
    }

    private List<Card> splitDeck(List<Card> arr, int from, int to)
    {
        List<Card> res = new List<Card>();
        bool inRange = false;
        for (int i = 0; i < arr.Count; i++)
        {
            if (i == from)
            {
                inRange = true;
            }

            if (i == to)
            {
                inRange = false;
            }

            if (inRange)
            {
                res.Add(arr[i]);
            }
        }

        return res;
    }
}