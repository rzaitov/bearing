﻿using System;

using CommandLine;

namespace PageGenerator
{
	public class Options
	{
		[Option(Required = true)]
		public string Dictionary { get; set; }

        [Option("price", Required = true)]
        public string PriceListPath { get; set; }

		[Option(Required = true)]
		public string Storage { get; set; }

		[Option("finishtemplate", Required = true)]
		public string FinishPageTemplate { get; set; }

		[Option("tabletemplate", Required = true)]
		public string TablePageTemplate { get; set; }

		[Option(Default = "Output")]
		public string OutputDir { get; set; }

		[Option("pages", Default = false)]
		public bool Pages { get; set; }

		[Option("yamarket", Default = false)]
		public bool YandexMarket { get; set; }
	}
}