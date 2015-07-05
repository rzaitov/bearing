using System;

using ExcelLibrary.SpreadSheet;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace SchemaGenerator
{
	class MainClass
	{
		const string storagePath = "/Users/rzaitov/Documents/Apps/_Bearing";
		public static void Main (string[] args)
		{
			DictionaryReader dictReader = new DictionaryReader ("Dictionary.xls", storagePath);
			DictionaryValidationReport validationReport = dictReader.Validate ();
			validationReport.Print ();

//			var tr = new TableReader ();
//			tr.Read ("/skf/Подшипники/Шариковые/Шариковые Упорные/Упорные шарикоподшипники, одинарные.xls");
		}
	}
}
