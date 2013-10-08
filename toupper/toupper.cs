using System;

namespace toupper
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			String line;
			while((line = Console.In.ReadLine()) != null) {
				Console.WriteLine(line.ToUpper());
			}
		}
	}
}
