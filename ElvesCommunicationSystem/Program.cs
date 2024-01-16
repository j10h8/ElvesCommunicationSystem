using ElvesCommunicationSystem;

DataService dataService = new DataService();

dataService.PrintResult("input.txt");

char[] screenPixels = new char[240];
int[] register = dataService.CreateRegister(dataService.ReadDataInput("input.txt"));

for (int i = 0; i < screenPixels.Length; i++)
{
    if (i < 40)
    {
        if (register[i] == i || register[i] == i + 1 || register[i] == i - 1)
        {
            screenPixels[i] = '#';
        }
        else
        {
            screenPixels[i] = '.';
        }
    }
    else if (i > 39 && i < 80)
    {
        if (register[i] == i - 40 || register[i] == i + 1 - 40 || register[i] == i - 1 - 40)
        {
            screenPixels[i] = '#';
        }
        else
        {
            screenPixels[i] = '.';
        }
    }
    else if (i > 79 && i < 120)
    {
        if (register[i] == i - 80 || register[i] == i + 1 - 80 || register[i] == i - 1 - 80)
        {
            screenPixels[i] = '#';
        }
        else
        {
            screenPixels[i] = '.';
        }
    }
    else if (i > 119 && i < 159)
    {
        if (register[i] == i - 120 || register[i] == i + 1 - 120 || register[i] == i - 1 - 120)
        {
            screenPixels[i] = '#';
        }
        else
        {
            screenPixels[i] = '.';
        }
    }
    else if (i > 160 && i < 200)
    {
        if (register[i] == i - 160 || register[i] == i + 1 - 160 || register[i] == i - 1 - 160)
        {
            screenPixels[i] = '#';
        }
        else
        {
            screenPixels[i] = '.';
        }
    }
    else
    {
        if (register[i] == i - 200 || register[i] == i + 1 - 200 || register[i] == i - 1 - 200)
        {
            screenPixels[i] = '#';
        }
        else
        {
            screenPixels[i] = '.';
        }
    }
}

for (int i = 0; i < screenPixels.Length; i++)
{
    Console.Write(screenPixels[i]);

    if ((i + 1) % 40 == 0)
    {
        Console.WriteLine();
    }
}

Console.ReadKey();
