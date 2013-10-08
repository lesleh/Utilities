using System;
using System.Diagnostics;
using System.IO;

namespace data_uri
{
	class MainClass
	{
		public static int Main (string[] args)
		{
			if(args.Length != 1) {
				Console.Error.WriteLine("Error: No filename specified.");
				return 1;
			}

			string filename = args[0];

			try {
				DataUri(filename, Console.Out);
			} catch(IOException ex) {
				Console.Error.WriteLine("Error: failed to create data URI.");
				Console.Error.WriteLine(ex.ToString());
				return 1;
			}

			return 0;
		}

		private static string GetMimeType (string filename)
		{
			ProcessStartInfo startInfo = new ProcessStartInfo("file", "--mime-type --brief \"" + filename + "\"");
			startInfo.UseShellExecute = false;
			startInfo.RedirectStandardOutput = true;

			Process p = Process.Start(startInfo);
			return p.StandardOutput.ReadToEnd().Trim();
		}

		private static void DataUri (String filename, TextWriter writer)
		{
			using(FileStream fs = new FileStream(filename, FileMode.Open)) {
				writer.Write("data:");
				writer.Write(GetMimeType(filename));
				writer.Write(";base64,");

				int count;
				byte[] buffer = new byte[1024 * 3]; // Make sure to use a multiple of 3
				do {
					count = fs.Read(buffer, 0, buffer.Length);
					writer.Write(Convert.ToBase64String(buffer, 0, count));
				} while(count > 0);

				writer.WriteLine();
			}
		}
	}
}
