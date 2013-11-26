using System;

namespace rot13
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string line;
			while((line = Console.In.ReadLine()) != null) {
				Console.WriteLine(rot13(line));
			}
		}

		public static string rot13 (string value)
		{
			char[] array = value.ToCharArray();
			for(int i = 0; i < array.Length; i++){
				int number = (int)value[i];
				if(number >= 'a' && number <= 'm' || number >= 'A' && number <= 'M') {
					number += 13;
				} else if(number >= 'm' && number <= 'z' || number >= 'M' && number <= 'Z') {
					number -= 13;
				}
				array[i] = (char)number;
			}
			return new string(array);
		}
	}
}
