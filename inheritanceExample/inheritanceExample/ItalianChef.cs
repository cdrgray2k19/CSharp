namespace inheritanceExample;

public class ItalianChef : Chef
{
    private string favPasta;
    public ItalianChef(string name, int age, int angerThreshold, string favPasta) : base(name, age, angerThreshold)
    {
        this.favPasta = favPasta;
    }

    public string getFavPasta()
    {
        return favPasta;
    }

    public override void MakeSpecialDish()
    {
        Console.WriteLine($"chef makes {favPasta}");
    }

    public override void Shout()
    {
        Console.WriteLine("dov'è la salsa di agnello");
    }
}