using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace wordwrap
{
	class MainClass
	{
		private static int WRAP_LENGTH = 80;

		public static void Main (string[] args)
		{
			Wrap(Console.In, Console.Out, WRAP_LENGTH, true);
		}

		private static void Wrap(TextReader input, TextWriter output, int count, bool force)
		{
			string line;
			while((line = input.ReadLine()) != null)
			{
				string wrapped = SplitString(line, count, force);
				output.Write(wrapped);
			}
		}

		private static string SplitString(string str, int wrapLength, bool wrapLongWords)
		{
			StringBuilder wrappedLine = new StringBuilder(str.Length + 32);

			int inputLineLength = str.Length;
			int offset = 0;

			while ((inputLineLength - offset) > wrapLength) {
				if (str[offset] == ' ') {
					offset++;
					continue;
				}
				int spaceToWrapAt = str.LastIndexOf(' ', wrapLength + offset);

				if (spaceToWrapAt >= offset) {
					// normal case
					wrappedLine.Append(str.Substring(offset, spaceToWrapAt - offset));
					wrappedLine.Append('\n');
					offset = spaceToWrapAt + 1;
				}/* else {
					// really long word or URL
					if (wrapLongWords) {
						// wrap really long word one line at a time
						wrappedLine.append(str.substring(offset, wrapLength + offset));
						wrappedLine.append(newLineStr);
						offset += wrapLength;
					} else {
						// do not wrap really long word, just extend beyond limit
						spaceToWrapAt = str.indexOf(' ', wrapLength + offset);
						if (spaceToWrapAt >= 0) {
							wrappedLine.append(str.substring(offset, spaceToWrapAt));
							wrappedLine.append(newLineStr);
							offset = spaceToWrapAt + 1;
						} else {
							wrappedLine.append(str.substring(offset));
							offset = inputLineLength;
						}
					}
				}*/
			}

			// Whatever is left in line is short enough to just pass through
			wrappedLine.Append(str.Substring(offset));

			return wrappedLine.ToString();
		}
	}
}
