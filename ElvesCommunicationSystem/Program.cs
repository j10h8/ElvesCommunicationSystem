// Read values from input file and store in array 
string[] input = File.ReadAllLines("..\\..\\..\\Input\\ExampleInput.txt");

#region Determine number of cycles that input generates, and create array based on result 
int numberOfCycles = 0;

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
#endregion

#region Iterate over input to generate X values for CPU register 
int cycle = 0;
int registerXValue = 1;

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
#endregion

#region Calculate requested value 
int sumOfSignalStrengths = 0;
int j = 19;

while (j < 220)
{
    sumOfSignalStrengths += (registerX[j] * (j + 1));

    j = j + 40;
}
#endregion

#region Print result to console 
for (int c = 0; c < registerX.Length; c++)
{
    Console.Write($"{c + 1} {registerX[c]} \n");
}

Console.Write("\n");
Console.WriteLine("Press any key to exit.");
Console.WriteLine(registerX[19] + "\n");
Console.WriteLine(registerX[59] + "\n");
Console.WriteLine(registerX[99] + "\n");
Console.WriteLine(registerX[139] + "\n");
Console.WriteLine(registerX[179] + "\n");
Console.WriteLine(registerX[219] + "\n");
Console.WriteLine(sumOfSignalStrengths + "\n");
Console.ReadKey();
#endregion