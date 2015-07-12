using System;

namespace PageGenerator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var tg = new TableGenerator ();
			Console.WriteLine (tg.Generate());
		}
	}
}
