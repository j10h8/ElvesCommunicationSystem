namespace ElvesCommunicationSystem
{
    public class DataService
    {
        /// <summary>
        /// Reads the contents of a file and returns an array of strings, where each element
        /// represents a line in the file.
        /// </summary>
        /// <param name="fileName">The name of the file to read.</param>
        /// <returns>An array of strings representing the lines in the file. Returns an empty array if the file is empty or not found.</returns>
        public string[] ReadDataInput(string fileName)
        {
            return File.ReadAllLines($"..\\..\\..\\Input\\{fileName}");
        }

        /// <summary>
        /// Creates an array of ints and populates it with values. 
        /// </summary>
        /// <param name="input">An array of strings.</param>
        /// <returns>
        /// An array of integers corresponding to the values from the input array.
        /// </returns>
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

        /// <summary>
        /// Populates the int[] register with values from the string[] input.
        /// </summary>
        /// <param name="input">An array of strings.</param>
        /// <param name="register">An array of integers.</param>
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

        /// <summary>
        /// Calculates the sum of the signal strengths at indices 20, 60, 100, 140, 180 and 220.
        /// </summary>
        /// <param name="register">An array of ints.</param>
        /// <returns>
        /// An integers corresponding to the calculated sum of signal strengths. 
        /// </returns>
        public int GetSumOfSignalStrengths(int[] register)
        {
            if (register.Length < 239)
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

        /// <summary>
        /// Prints the result of the calculations. 
        /// </summary>
        /// <param name="fileName">A string corresponding to the name of the input file.</param>
        public void PrintResult(string fileName)
        {
            int[] register = CreateRegister(ReadDataInput(fileName));
            int sumOfSignalStrengths = GetSumOfSignalStrengths(register);

            //// For checking values. Prints X value at each cycle. 
            //for (int c = 0; c < register.Length; c++)
            //{
            //    Console.WriteLine($"{c + 1} {register[c]}");
            //}

            Console.WriteLine();

            int d = 20;

            while (d <= 220)
            {
                Console.WriteLine("  " + register[d - 1] * d + $" ({register[d - 1]} * {d})");
                d = d + 40;
            }

            Console.WriteLine("+ _______________");
            Console.WriteLine("  " + sumOfSignalStrengths);
            Console.WriteLine();
            Console.WriteLine($"The sum of the signal strengths is {sumOfSignalStrengths}");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints screen "pixels" based on the provided input file(name). 
        /// </summary>
        /// <param name="fileName">A string corresponding to the name of the input file.</param>
        internal void PrintScreen(string fileName)
        {
            char[] screenPixels = new char[240];
            int[] register = CreateRegister(ReadDataInput(fileName));

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

            Console.WriteLine("The provided instructions input generates the following screen:");
            Console.WriteLine();

            for (int i = 0; i < screenPixels.Length; i++)
            {
                Console.Write(screenPixels[i]);

                if ((i + 1) % 40 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
