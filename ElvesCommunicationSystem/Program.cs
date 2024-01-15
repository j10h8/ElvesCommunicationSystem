string[] input = File.ReadAllLines("..\\..\\..\\Input\\TestInput.txt");

for (int cycle = 0; cycle < input.Length; cycle++)
{
    if (input[cycle].StartsWith("addx"))
    {
        string[] splitInstruction = input[cycle].Split(' ');

        if (int.TryParse(splitInstruction[1], out int V))
        {
            // Do stuff with V 
        }
        else
        {
            throw new Exception("Bad instruction. Could not parse value.");
        }


        // split and use int to alter register value
    }
    else
    {
        // noop... 
    }

    Console.WriteLine(input[cycle]);
}

Console.Write("\n");
Console.WriteLine("Press any key to exit.");
Console.ReadKey();
