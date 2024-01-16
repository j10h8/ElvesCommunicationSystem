namespace ElvesCommunicationSystem
{
    public class DataService
    {
        public string[] ReadDataInput(string fileName)
        {
            return File.ReadAllLines($"..\\..\\..\\Input\\{fileName}");
        }

        public int[] CreateRegister(string[] input)
        {
            int numberOfCycles = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].StartsWith("addx"))
                {
                    numberOfCycles += 2;
                }
                else
                {
                    numberOfCycles++;
                }
            }

            int[] register = new int[numberOfCycles];

            GenerateRegisterValues(input, register);

            return register;
        }

        public void GenerateRegisterValues(string[] input, int[] register)
        {
            int cycle = 0;
            int registerValue = 1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].StartsWith("addx"))
                {
                    register[cycle] = registerValue;
                    cycle++;
                    register[cycle] = registerValue;
                    cycle++;

                    string[] splitInstruction = input[i].Split(' ');

                    if (int.TryParse(splitInstruction[1], out int V))
                    {
                        registerValue += V;
                    }
                    else
                    {
                        throw new Exception("Bad instruction. Could not parse V value.");
                    }
                }
                else
                {
                    register[cycle] = registerValue;
                    cycle++;
                }
            }
        }

        public int GetSumOfSignalStrengths(int[] register)
        {
            if (register.Length < 19)
            {
                throw new Exception("Insufficient number of instructions. Could not get sum of signal strengths.");
            }
            else
            {
                int sumOfSignalStrengths = 0;
                int i = 19;

                while (i < 220)
                {
                    sumOfSignalStrengths += (register[i] * (i + 1));

                    i = i + 40;
                }

                return sumOfSignalStrengths;
            }
        }

        public void PrintResult(string fileName)
        {
            int[] register = CreateRegister(ReadDataInput(fileName));
            int sumOfSignalStrengths = GetSumOfSignalStrengths(register);

            for (int c = 0; c < register.Length; c++)
            {
                Console.WriteLine($"{c + 1} {register[c]}");
            }

            Console.Write("\n");

            int d = 20;
            while (d <= 220)
            {
                Console.WriteLine("  " + register[d - 1] * d + $" ({register[d - 1]} * {d})");
                d = d + 40;
            }

            Console.WriteLine("+ _______________");
            Console.WriteLine("  " + sumOfSignalStrengths);
            Console.Write("\n");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
