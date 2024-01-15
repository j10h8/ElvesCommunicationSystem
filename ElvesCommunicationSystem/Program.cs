
string[] testInput = File.ReadAllLines("..\\..\\..\\Input\\TestInput.txt");

foreach (string line in testInput)
{
    Console.WriteLine(line);
}

Console.WriteLine("Press any key to exit.");
Console.ReadKey();
