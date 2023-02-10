namespace inheritanceExample;

public class Chef
{
    private string name;
    private int age;
    private int angerThreshold;

    public Chef(string name, int age, int angerThreshold)
    {
        this.name = name;
        this.age = age;
        this.angerThreshold = angerThreshold;
    }

    public string getName()
    {
        return name;
    }
    
    public int getAge()
    {
        return age;
    }
    public int getAnger()
    {
        return angerThreshold;
    }

    public void MakeSoup()
    {
        Console.WriteLine("chef makes soup");
    }
    public void MakeStew()
    {
        Console.WriteLine("chef makes stew");
    }
    public virtual void MakeSpecialDish()
    {
        Console.WriteLine("chef makes special dish");
    }

    public virtual void Shout()
    {
        Console.WriteLine("Where's the lamb sauce!");
    }
}