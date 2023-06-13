namespace inheritanceExample;

public class JapaneseChef : Chef
{
    private string favSushi;

    public JapaneseChef(string name, int age, int angerThreshold, string favSushi) : base(name, age, angerThreshold)
    {
        this.favSushi = favSushi;
    }
    
    public string getFavSushi()
    {
        return favSushi;
    }

    public override void MakeSpecialDish()
    {
        Console.WriteLine($"chef makes {favSushi}");
    }

    public override void Shout()
    {
        Console.WriteLine("ティーポットエラー");
    }
}