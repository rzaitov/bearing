using System;

using RazorEngine;
using RazorEngine.Templating;
using RazorEngine.Compilation.CSharp;

namespace PageGenerator
{
	public class TableGenerator
	{
		const string template = @"Hello @Model.Name, welcome to RazorEngine!";
		public TableGenerator ()
		{
			var t = typeof (CSharpCodeParser);
		}

		public string Generate ()
		{
			string result = Engine.Razor.RunCompile(template, "templateKey", typeof(TablePage), new TablePage ());
			return result;
		}
	}
}

