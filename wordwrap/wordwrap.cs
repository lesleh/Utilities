using System;
using System.IO;
using System.Collections.Generic;

namespace wordwrap
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Wrap(Console.In, Console.Out, 80, true);
		}

		private static void Wrap(TextReader input, TextWriter output, int count, bool force)
		{
			string line;
			while((line = input.ReadLine()) != null)
			{
				string[] parts = SplitString(line, count, force);
				foreach(string part in parts)
				{
					output.WriteLine(part);
				}
			}
		}

		private static string[] SplitString(string input, int count, bool force)
		{
			var parts = new List<string>();

			// TODO Naive implementation, fix later
			int start = 0;
			int end = (input.Length < count) ? input.Length : count;
			while(start < input.Length) {
				if(end < input.Length) {
					while(!char.IsWhiteSpace(input[end - 1]))
						end--;
				}
				parts.Add(SafeSubstring(input, start, end - start));
				start = end;
				end += count;
			}

			return parts.ToArray();
		}

		public static string SafeSubstring(string text, int start, int length)
		{
			return text.Length <= start ? string.Empty
					: text.Length - start <= length ? text.Substring(start)
					: text.Substring(start, length);
		}
	}
}
