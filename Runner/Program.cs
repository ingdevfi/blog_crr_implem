using System;
using System.Diagnostics;
using System.IO;

namespace Runner {
	internal class Program {
		private static void Main(string[] args) {
			var chrono = new Stopwatch();
			var currentDir = Directory.GetCurrentDirectory();
			//Console.WriteLine(currentDir);

			//
			// C# Implem
			//
			var csharpPah = Path.Combine(currentDir, "..\\..\\..\\CRR_CSharp\\bin\\Release\\CRR_CSharp.exe");

			var csharpImplem = new Process {StartInfo = {FileName = csharpPah}};

			Console.WriteLine("Starting C# implementation in:\n {0}", csharpImplem.StartInfo.FileName);
			chrono.Restart();

			csharpImplem.Start();
			csharpImplem.WaitForExit();
			chrono.Stop();

			Console.WriteLine();
			Console.WriteLine(@"C# implementation took {0:#,#}ticks = {1:#,#}ms", chrono.ElapsedTicks, chrono.ElapsedMilliseconds);
			Console.WriteLine("----------------------------------------------");
			Console.WriteLine();

			//
			// F# Implem
			//
			var fsharpPah = Path.Combine(currentDir, "..\\..\\..\\CRR_FSharp\\bin\\Release\\CRR_FSharp.exe");

			var fsharpImplem = new Process { StartInfo = { FileName = fsharpPah } };

			Console.WriteLine("Starting F# implementation in:\n {0}", csharpImplem.StartInfo.FileName);
			chrono.Restart();

			fsharpImplem.Start();
			fsharpImplem.WaitForExit();
			chrono.Stop();

			Console.WriteLine();
			Console.WriteLine(@"F# implementation took {0:#,#}ticks = {1:#,#}ms", chrono.ElapsedTicks, chrono.ElapsedMilliseconds);
			Console.WriteLine("----------------------------------------------");
			Console.WriteLine();

			//
			// C++ Implem
			//
			var cppPah = Path.Combine(currentDir, "..\\..\\..\\CRR_CPP\\x64\\Release\\CRR_CPP.exe");

			var cppImplem = new Process {StartInfo = {FileName = cppPah}};

			Console.WriteLine("Starting C++ implementation in:\n {0}", cppImplem.StartInfo.FileName);
			chrono.Restart();

			cppImplem.Start();
			cppImplem.WaitForExit();
			chrono.Stop();

			Console.WriteLine();
			Console.WriteLine(@"C++ implementation took {0:#,#}ticks = {1:#,#}ms", chrono.ElapsedTicks,
				chrono.ElapsedMilliseconds);
			Console.WriteLine("----------------------------------------------");
			Console.WriteLine();

			Console.ReadLine();
		}
	}
}