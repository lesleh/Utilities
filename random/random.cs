using System;
using System.Collections.Generic;

namespace random
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			List<string> lines = new List<string>();
			string line;

			while((line = Console.In.ReadLine()) != null) {
				lines.Add(line);
			}

			Random random = new Random();
			line = lines[random.Next(lines.Count)];

			Console.WriteLine(line);
		}
	}
}
