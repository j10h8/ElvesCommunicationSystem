using ElvesCommunicationSystem;

DataService dataService = new DataService();

dataService.PrintResult("input.txt");

char[] screenPixels = new char[240];
int[] register = dataService.CreateRegister(dataService.ReadDataInput("input.txt"));


int j = 0;

for (int i = 0; i < screenPixels.Length; i++)
{
    switch (i)
    {
        case 40:
            j = 40;
            break;
        case 80:
            j = 80;
            break;
        case 120:
            j = 120;
            break;
        case 160:
            j = 160;
            break;
        case 200:
            j = 200;
            break;
        default:
            break;
    }

    if (register[i] == i - j || register[i] == i + 1 - j || register[i] == i - 1 - j)
    {
        screenPixels[i] = '#';
    }
    else
    {
        screenPixels[i] = '.';
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
