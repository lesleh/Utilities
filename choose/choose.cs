using System;

namespace choose
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Random random = new Random();
			int key = random.Next(args.Length);
			Console.WriteLine(args[key]);
		}
	}
}
