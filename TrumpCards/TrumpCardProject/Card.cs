namespace TrumpCardProject;

public class Card
{
    private List<int> fields = new List<int>(6);

    public Card(List<int> nums)
    {
        for (int i = 0; i < nums.Count; i++)
        {
            fields.Add(nums[i]);
        }
    }

    public int GetFieldVal(int ind)
    {
        return fields[ind];
    }

}