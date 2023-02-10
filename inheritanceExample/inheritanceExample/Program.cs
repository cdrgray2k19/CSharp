using System;
namespace inheritanceExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chef chef1 = new Chef("steve", 42, 10);
            Chef chef2 = new ItalianChef("Leonardo", 30, 17, "Pasta carbonara");
            Chef chef3 = new JapaneseChef("Ren", 27, 5, "Nigiri Sushi");
            
            chef1.MakeSoup();
            chef2.MakeSoup();
            chef3.MakeSoup();
            chef1.MakeStew();
            chef2.MakeStew();
            chef3.MakeStew();
            chef1.MakeSpecialDish();
            chef2.MakeSpecialDish();
            chef3.MakeSpecialDish();
            chef1.Shout();
            chef2.Shout();
            chef3.Shout();
        }
    }
}