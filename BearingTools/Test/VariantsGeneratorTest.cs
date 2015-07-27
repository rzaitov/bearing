using System;
using NUnit.Framework;

using Core;
using System.Linq;

namespace Test
{
	[TestFixture()]
	public class VariantsGeneratorTest
	{
		[Test()]
		public void SkfVariants ()
		{
			var builder = new GeneratorBuilder ("skf");
			var generator = builder.Build ();

			CollectionAssert.AreEqual (new string []{"SKF", "СКФ"}, generator.GetVariants ());
		}

		[Test()]
		public void UniqVariant ()
		{
			var builder = new GeneratorBuilder ("xyz");
			var generator = builder.Build ();

			CollectionAssert.AreEqual (new string []{"xyz"}, generator.GetVariants ());
		}

		[Test()]
		public void VariantWitSingleSeparator ()
		{
			var builder = new GeneratorBuilder ("abc-xyz");
			var generator = builder.Build ();

			CollectionAssert.AreEquivalent (new string []{"abc-xyz", "abc xyz", "abcxyz"}, generator.GetVariants ());
		}

		[Test()]
		public void VariantWitMultiSeparator ()
		{
			var builder = new GeneratorBuilder ("a + b");
			var generator = builder.Build ();

			var variants = generator.GetVariants ();
			foreach (var item in variants) {
				Console.WriteLine (item);
			}
			CollectionAssert.AreEquivalent (new string []{"a + b", "a+ b", "a +b", "a+b", "a b", "ab"}, variants);
		}
	}
}