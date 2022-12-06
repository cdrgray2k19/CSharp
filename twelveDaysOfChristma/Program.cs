// See https://aka.ms/new-console-template for more information

List<double> prices = new List<double>{15.99, 6.59, 4.37, 2.98, 44.99, 8.50, 30, 650, 800, 700, 900, 700};
double total = 0;
int presents = 0;
for (int i = 0; i < prices.Count; i++)
{
    int newPresents = (i + 1) * (12 - i);
    presents += newPresents;
    total += newPresents * prices[i];
}
Console.WriteLine(presents);
Console.WriteLine(total);