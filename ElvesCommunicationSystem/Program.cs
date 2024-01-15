string[] input = File.ReadAllLines("..\\..\\..\\Input\\TestInput.txt");

int registerXValue = 1;
int numberOfCycles = 1;

for (int h = 0; h < input.Length; h++)
{
    if (input[h].StartsWith("addx"))
    {
        numberOfCycles += 2;
    }
    else
    {
        numberOfCycles++;
    }
}

int[] registerX = new int[numberOfCycles];

int cycle = 0;

for (int i = 0; i < input.Length; i++)
{
    if (input[i].StartsWith("addx"))
    {
        registerX[cycle] = registerXValue;
        cycle++;
        registerX[cycle] = registerXValue;
        cycle++;

        string[] splitInstruction = input[i].Split(' ');

        if (int.TryParse(splitInstruction[1], out int V))
        {
            registerXValue += V;
        }
        else
        {
            throw new Exception("Bad instruction (could not parse V value)");
        }
    }
    else
    {
        registerX[cycle] = registerXValue;
        cycle++;
    }
}

registerX[cycle] = registerXValue;

foreach (int value in registerX)
{
    Console.Write(value + " ");
}

Console.Write("\n");
Console.WriteLine("Press any key to exit.");
Console.ReadKey();
