// Copyright (c) 2015 SIL International
// This software is licensed under the MIT License (http://opensource.org/licenses/MIT)
using System;
using System.IO;
using System.Diagnostics;
using NUnit.Framework;

namespace TcProblem
{
	[TestFixture]
	class Tests
	{
		[Test]
		public void ThisTest()
		{
			var dir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
			Directory.CreateDirectory(dir);
			var file = Path.Combine(dir, "base.lift");
			File.WriteAllText(file, "Some content");
			Console.WriteLine("Readonly {0}: {1}", file, File.GetAttributes(file));
			File.SetAttributes(file, FileAttributes.ReadOnly);
			Console.WriteLine("Readonly {0}: {1}", file, File.GetAttributes(file));
		}
	}
	class MainClass
	{
		public static void Main(string[] args)
		{

			var t = new Tests();
			t.ThisTest();

			if (args.Length > 0)
			{
				var file = args[0];
				Console.WriteLine("Readonly {0}: {1}", file, File.GetAttributes(file));
			}
		}
	}
}
