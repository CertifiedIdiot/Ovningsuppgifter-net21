using System;

namespace Bubbelsort
{
    class Program
    {
        static void Main()
        {
            // Tilldelning av slumpmässiga tal.
            int[] numbers = new int[10];
            for(int i = 0; i < 10; i++)
            {
                Random rnd = new Random();
                numbers[i] = rnd.Next(1, 50);

            }

            // Sortering av tal.
            bool changed = false;
            do
            {
                changed = false;
                for(int i = 0; i != 9; i++)
                {
                    if(numbers[i] < numbers[i + 1])
                    {
                        int numTemp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = numTemp;
                        changed = true;
                    }
                }
            } while (changed == true);

            // Utmatning av tal.
            foreach(int numTemp in numbers)
            {
                Console.WriteLine(numTemp);
            }
        }
    }
}
