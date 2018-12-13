using System;
using System.Collections.Generic;
using System.IO;

namespace Day1
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = ReadInput();
			Part1(input);
			Part2(input);
			Console.ReadKey(intercept: true);
		}

		private static void Part1(List<int> input)
		{
			/*
            After feeling like you've been falling for a few minutes, you look at the
            device's tiny screen. "Error: Device must be calibrated before first use.
            Frequency drift detected. Cannot maintain destination lock." Below the
            message, the device shows a sequence of changes in frequency (your puzzle
            input). A value like +6 means the current frequency increases by 6; a value
            like -3 means the current frequency decreases by 3.

            For example, if the device displays frequency changes of +1, -2, +3, +1,
            then starting from a frequency of zero, the following changes would occur:
            - Current frequency  0, change of +1; resulting frequency  1.
            - Current frequency  1, change of -2; resulting frequency -1.
            - Current frequency -1, change of +3; resulting frequency  2.
            - Current frequency  2, change of +1; resulting frequency  3.

            In this example, the resulting frequency is 3.

            Here are other example situations:
                +1, +1, +1 results in  3
                +1, +1, -2 results in  0
                -1, -2, -3 results in -6

            Starting with a frequency of zero, what is the resulting frequency after
            all of the changes in frequency have been applied?
            */

			int freq = 0;

			foreach (var change in input)
			{
				freq += change;
			}

			Console.WriteLine($"Answer: {freq}");
		}

		private static List<int> ReadInput()
		{
			var list = new List<int>();
			using (var reader = new StreamReader("..\\..\\input.txt"))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					int positive = line[0] == '+' ? 1 : -1;
					int change = int.Parse(line.Substring(1));

					list.Add(change * positive);
				}
			}

			return list;
		}

		private static void Part2(List<int> input)
		{
			/*
			You notice that the device repeats the same frequency change list over and
			over. To calibrate the device, you need to find the first frequency it
			reaches twice.

			For example, using the same list of changes above, the device would loop as
			follows:
				Current frequency  0, change of +1; resulting frequency  1.
				Current frequency  1, change of -2; resulting frequency -1.
				Current frequency -1, change of +3; resulting frequency  2.
				Current frequency  2, change of +1; resulting frequency  3.
				(At this point, the device continues from the start of the list.)
				Current frequency  3, change of +1; resulting frequency  4.
				Current frequency  4, change of -2; resulting frequency  2, which has
				already been seen.

			In this example, the first frequency reached twice is 2. Note that your
			device might need to repeat its list of frequency changes many times before
			a duplicate frequency is found, and that duplicates might be found while in
			the middle of processing the list.

			Here are other examples:
				+1, -1 first reaches 0 twice.
				+3, +3, +4, -2, -4 first reaches 10 twice.
				-6, +3, +8, +5, -6 first reaches 5 twice.
				+7, +7, -2, -7, -4 first reaches 14 twice.

			What is the first frequency your device reaches twice?
			*/
			var set = new HashSet<int>();
			int? answer = null;
			int freq = 0;

			while (answer == null)
			{
				foreach (var change in input)
				{
					freq += change;
					if (set.Contains(freq))
					{
						answer = freq;
						break;
					}
					else
					{
						set.Add(freq);
					}
				}
			}

			Console.WriteLine($"Answer 2: {answer}");
		}
	}
}
